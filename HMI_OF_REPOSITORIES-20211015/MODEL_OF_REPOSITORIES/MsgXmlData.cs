//********************************************************************
//** Copyright (c) 2015 宝信软件
//** 创建人：张晓荣
//** 类名称\文件名：MsgXmlData.cs
//** 类功能：电文配置文件实体类
//** 描述：一个配置文件有多条回线
//** 创建日期：2015-2-2
//** 修改人：
//** 修改日期：
//** 整理日期：
//********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODEL_OF_REPOSITORIES
{
    // 电文配置文件
    public class MsgXmlData
    {
        // 回线集合
        public MsgDataGroupCollection GroupCollection = new MsgDataGroupCollection();
    }
}
