//********************************************************************
//** Copyright (c) 2015 宝信软件
//** 创建人：张晓荣
//** 类名称\文件名：MsgData.cs
//** 类功能：电文实体类
//** 描述：一条电文内包含多个字段
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

namespace MODEL_OF_REPOSITORIES
{
    // 电文方向
    public enum DIRECTION
    {
        UNSET,       // 未设定
        SEND,       // 发送
        RECV       // 接收
    }

    // 电文信息
    public class MsgData
    {
        // 电文号
        public String msgId = "电文号";
        // 电文含义
        public String comment = "备注";
        // 电文内容
        public String content = "";
        // 电文方向
        public DIRECTION direction = DIRECTION.UNSET;
        // 普通字段集
        public MsgStandFieldCollection StandFields = new MsgStandFieldCollection();
        // 递归字段集
        public MsgRecuFieldCollection RecuFields = new MsgRecuFieldCollection();
    }

    // 电文集
    public class MsgDataCollection : ICollection
    {
        public String CollectionName = "电文集合";
        public ArrayList MsgDataList = new ArrayList();

        public MsgData this[int index]
        {
            get { return (MsgData)MsgDataList[index]; }
        }
        public void CopyTo(Array a, int index)
        {
            MsgDataList.CopyTo(a, index);
        }
        public int Count
        {
            get { return MsgDataList.Count; }
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
            return MsgDataList.GetEnumerator();
        }
        public void Add(MsgData data)
        {
            MsgDataList.Add(data);
        }
    }
}
