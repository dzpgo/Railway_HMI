//********************************************************************
//** Copyright (c) 2015 宝信软件
//** 创建人：张晓荣
//** 类名称\文件名：MsgDataGroup.cs
//** 类功能：回线实体类
//** 描述：一个回线有多条电文
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
    // 回线信息
    public class MsgDataGroup
    {
        // 回线名
        public string Name = "回线名";
        // 电文集合
        public MsgDataCollection msgDataCollection = new MsgDataCollection();
    }

    // 回线集
    public class MsgDataGroupCollection : ICollection
    {
        public String CollectionName = "回线集合";
        public ArrayList MsgDataGroupList = new ArrayList();

        public MsgDataGroup this[int index]
        {
            get { return (MsgDataGroup)MsgDataGroupList[index]; }
        }
        public void CopyTo(Array a, int index)
        {
            MsgDataGroupList.CopyTo(a, index);
        }
        public int Count
        {
            get { return MsgDataGroupList.Count; }
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
            return MsgDataGroupList.GetEnumerator();
        }
        public void Add(MsgDataGroup data)
        {
            MsgDataGroupList.Add(data);
        }
    }
}
