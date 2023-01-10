//********************************************************************
//** Copyright (c) 2015 宝信软件
//** 创建人：张晓荣
//** 类名称\文件名：MsgRecuField.cs
//** 类功能：可循环字段信息实体类
//** 描述：字段为电文中最小单位
//** 创建日期：2015-2-2
//** 修改人：
//** 修改日期：
//** 整理日期：
//********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Xml.Serialization;

namespace MODEL_OF_REPOSITORIES
{
    // 循环类型字段信息
    public class MsgRecuField
    {
        // 字段名称
        public String name = "字段名称";
        // 循环计数标记
        public bool bRecurFlag = false;
        // 字段长度
        public int length = 1;
        // 字段类型
        public DATATYPE type = DATATYPE.STRING;
        // 字段含义
        public string comment = "备注";
        // 值列表
        [XmlIgnore]
        public FieldValues values = new FieldValues();
        // 模拟值
        [XmlIgnore]
        public String simuValue = "";
    }

    // 字段值集合
    public class FieldValues : ICollection
    {
        public string CollectionName = "字段值集合";
        public ArrayList dataArry = new ArrayList();

        public String this[int index]
        {
            get { return (String)dataArry[index]; }
        }
        public void CopyTo(Array a, int index)
        {
            dataArry.CopyTo(a, index);
        }
        public int Count
        {
            get { return dataArry.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return dataArry.GetEnumerator();
        }
        public void Add(String data)
        {
            dataArry.Add(data);
        }
    }

    // 循环类型字段集合
    // 普通字段集合
    public class MsgRecuFieldCollection : ICollection
    {
        public string CollectionName = "循环字段集合";
        public ArrayList dataArry = new ArrayList();

        public MsgRecuField this[int index]
        {
            get { return (MsgRecuField)dataArry[index]; }
        }
        public void CopyTo(Array a, int index)
        {
            dataArry.CopyTo(a, index);
        }
        public int Count
        {
            get { return dataArry.Count; }
        }
        public object SyncRoot
        {
            get { return this; }
        }
        public bool IsSynchronized
        {
            get { return false; }
        }
        public IEnumerator GetEnumerator()
        {
            return dataArry.GetEnumerator();
        }
        public void Add(MsgRecuField data)
        {
            dataArry.Add(data);
        }
    }
}
