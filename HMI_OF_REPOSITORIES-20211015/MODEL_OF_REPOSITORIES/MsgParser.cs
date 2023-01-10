//********************************************************************
//** Copyright (c) 2015 宝信软件
//** 创建人：张晓荣
//** 类名称\文件名：MsgParser.cs
//** 类功能：电文解析类
//** 描述：电文解析操作实体类
//** 创建日期：2015-2-2
//** 修改人：
//** 修改日期：
//** 整理日期：
//********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;

namespace MODEL_OF_REPOSITORIES
{
    public class MsgParser
    {
        private MsgXmlData xmlData = null;
        private String strConfigFile = null;

        public MsgXmlData XmlData
        {
            get { return xmlData; }
            set { xmlData = value; }
        }

        public String ConfigPath
        {
            get { return strConfigFile; }
        }

        public MsgParser(string ConfigFile)
        {
            // 保存配置文件地址
            strConfigFile = ConfigFile;
            // 载入配置文件
            LoadConfig();

            //// tmp
            //CreateConfig();
        }

        public void LoadConfig()
        {
            // 准备xml文件地址
            String strAssemblyFilePath = Assembly.GetExecutingAssembly().Location;
            if (strAssemblyFilePath.LastIndexOf("\\") != -1)
            {
                strAssemblyFilePath = strAssemblyFilePath.Substring(0, strAssemblyFilePath.LastIndexOf("\\"));
                strConfigFile = strAssemblyFilePath + "\\" + strConfigFile;
            }

            // xml文件反序列化为对象
            DeSerialized(strConfigFile);
        }

        public void SaveConfig()
        {
            // xml文件反序列化为对象
            Serialized(strConfigFile);
        }

        public void CreateConfig()
        {
            // 准备xml文件地址
            String strAssemblyFilePath = Assembly.GetExecutingAssembly().Location;
            if (strAssemblyFilePath.LastIndexOf("\\") != -1)
            {
                strAssemblyFilePath = strAssemblyFilePath.Substring(0, strAssemblyFilePath.LastIndexOf("\\"));
                strConfigFile = strAssemblyFilePath + "\\" + strConfigFile;
            }

            // 创建临时对象
            CreateTestXmlData();

            // xml文件反序列化为对象
            Serialized(strConfigFile);
        }

        private void DeSerialized(String strConfigPath)
        {
            try
            {
                // 将配置xml文件反序列化
                XmlSerializer serialzer = new XmlSerializer(typeof(MsgXmlData));
                FileStream filestream = new FileStream(strConfigPath, FileMode.Open);
                xmlData = (MsgXmlData)serialzer.Deserialize(filestream);
                filestream.Close();
            }
            catch (System.Exception ex)
            {
                throw new SystemException(
                    String.Format("无法读取配置文件{0},{1}", strConfigFile, ex.Message));
            }
        }

        private void CreateTestXmlData()
        {
            // 创建文件用途

            // 字段
            MsgStandField field = new MsgStandField();
            field.name = "字段1";
            field.length = 4;
            field.type = DATATYPE.STRING;
            field.comment = "说明";
            field.bRecurFlag = false;

            // 电文
            MsgData msgData = new MsgData();
            msgData.msgId = "JSAS02";
            msgData.comment = "作业计划电文";
            msgData.StandFields.Add(field);

            // 回线
            MsgDataGroup group = new MsgDataGroup();
            group.msgDataCollection.Add(msgData);

            // 电文配置文件
            xmlData = new MsgXmlData();
            xmlData.GroupCollection.Add(group);
        }

        private void Serialized(String strConfigPath)
        {
            try
            {
                // XML对象序列化
                XmlSerializer serialzer = new XmlSerializer(typeof(MsgXmlData));
                StreamWriter writer = new StreamWriter(strConfigPath);
                serialzer.Serialize(writer, xmlData);
                writer.Close();
            }
            catch (System.Exception ex)
            {
                throw new SystemException(
                    String.Format("配置文件{0}无法保存,{1}", strConfigFile, ex.Message));
            }
        }

        public MsgData Parse(String messageid, Byte[] byteContent)
        {
            MsgData result = null;

            // 遍历电文配置表
            foreach (MsgDataGroup group in xmlData.GroupCollection)
            {
                foreach (MsgData msgData in group.msgDataCollection)
                {
                    // 查找电文号一致的配置信息
                    if (msgData.msgId.ToUpper() == messageid.ToUpper())
                    {
                        int nStartIndex = 0;
                        int nRecuCount = 0;
                        // 按此配置信息，解析文件
                        foreach (MsgStandField field in msgData.StandFields)
                        {

                            // 清空原数据
                            field.value = "";
                            // 用解析数据替代
                            // 修改用字节取代字符串截取数据
                            //field.value = content.Substring(nStartIndex, field.length);
                            byte[] byteField = new byte[field.length];
                            for (int index = 0; index < field.length; index++)
                            {
                                byteField[index] = byteContent[nStartIndex + index];
                            }
                            field.value = Encoding.Default.GetString(byteField);
                            // 准备处理下一个字段
                            nStartIndex += field.length;
                            // 检查字段是否有循环数据块
                            if (field.bRecurFlag)
                            {
                                Int32.TryParse(field.value, out nRecuCount);
                            }
                        }
                        // 有循环数据块
                        if (nRecuCount != 0)
                        {
                            int nBlockLength = 0;
                            // 计算循环数据块长度
                            foreach (MsgRecuField field in msgData.RecuFields)
                            {
                                nBlockLength += field.length;
                                // 清空原数据
                                field.values.dataArry.Clear();
                            }
                            // 对循环数据块进行解析
                            for (int nIndex = 0; nIndex < nRecuCount; nIndex++)
                            {
                                int nStartIndexInBlock = 0;
                                // 用字节处理代替字符串处理
                                //block = content.Substring(nStartIndex + nIndex * nBlockLength, nBlockLength);
                                byte[] byteBlock = new byte[nBlockLength];
                                for (int index = 0; index < nBlockLength; index++)
                                {
                                    byteBlock[index] = byteContent[nStartIndex + nIndex * nBlockLength + index];
                                }
                                // 数据块内按字段解析
                                foreach (MsgRecuField field in msgData.RecuFields)
                                {
                                    // 用字节处理代替字符串处理
                                    //String value = block.Substring(nStartIndexInBlock, field.length);
                                    byte[] byteField = new byte[field.length];
                                    for (int index = 0; index < field.length; index++)
                                    {
                                        byteField[index] = byteBlock[nStartIndexInBlock + index];
                                    }
                                    String value = Encoding.Default.GetString(byteField);
                                    field.values.Add(value);
                                    nStartIndexInBlock += field.length;
                                }
                            }
                        }

                        // 电文内容
                        msgData.content = Encoding.Default.GetString(byteContent);

                        // 电文内容
                        result = msgData;

                        // 返回
                        return result;
                    }
                }
            }

            throw new SystemException(
                String.Format("电文解析失败，配置信息中无电文号{0}的配置", messageid));
        }

        public MsgData Parse(String messageid, string[] ContentList)
        {
            MsgData result = null;
            int standFieldsCount = 0;
            int recuFieldsCount = 0;
            // 遍历电文配置表
            foreach (MsgDataGroup group in xmlData.GroupCollection)
            {
                foreach (MsgData msgData in group.msgDataCollection)
                {
                    // 查找电文号一致的配置信息
                    if (msgData.msgId.ToUpper() == messageid.ToUpper())
                    {
                        standFieldsCount = msgData.StandFields.Count;
                        recuFieldsCount = msgData.RecuFields.Count;
                        int nStartIndex = 0;
                        int nRecuCount = 0;
                        // 按此配置信息，解析文件
                        for (int i = 0; i < msgData.StandFields.Count; i++)
                        {
                            msgData.StandFields[i].value = ContentList[i];

                            // 检查字段是否有循环数据块
                            if (msgData.StandFields[i].bRecurFlag)
                            {
                                Int32.TryParse(msgData.StandFields[i].value, out nRecuCount);
                            }
                        }
                        // 计算循环数据块长度
                        foreach (MsgRecuField field in msgData.RecuFields)
                        {
                            // 清空原数据
                            field.values.dataArry.Clear();
                        }
                        int seq = 0;
                        for (int i = standFieldsCount; i < ContentList.Length; i++)
                        {
                            for (int j = 0; j < msgData.RecuFields.Count; j++)
                            {
                                if (seq*recuFieldsCount +(j+1) == (i-standFieldsCount+1))
                                {
                                    msgData.RecuFields[j].values.Add(ContentList[i]);
                                    break;
                                }
                            }
                            if ((i - standFieldsCount+1)% recuFieldsCount == 0)
                            {
                                seq++;
                            }
                            
                        }

                        // 电文内容
                        // msgData.content = Encoding.Default.GetString(byteContent);

                        // 电文内容
                        result = msgData;

                        // 返回
                        return result;
                    }
                }
            }

            throw new SystemException(
                String.Format("电文解析失败，配置信息中无电文号{0}的配置", messageid));
        }

        public String GenerateBufferData(MsgData msgData)
        {
            String BufferData = "";
            bool bRecuFlag = false;
            int nRecuCount = 0;

            foreach (MsgStandField standField in msgData.StandFields)
            {
                if (standField.bRecurFlag)
                {
                    bRecuFlag = true;
                    nRecuCount = Convert.ToInt32(standField.value);
                }

                BufferData += standField.value;
            }

            if (bRecuFlag)
            {
                for (int nIndex = 0; nIndex < nRecuCount; nIndex++)
                {
                    foreach (MsgRecuField recuField in msgData.RecuFields)
                    {
                        BufferData += recuField.values[nIndex];
                    }
                }
            }

            return BufferData;
        }
    }
}
