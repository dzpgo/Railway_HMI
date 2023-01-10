//********************************************************************
//** Copyright (c) 2015 宝信软件
//** 创建人：张晓荣
//** 类名称\文件名：MsgField.cs
//** 类功能：字段信息实体类
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
    // 字段类型
    public enum DATATYPE
    {
        STRING,  // 字符型
        INT
    }

    // 字段信息
    abstract public class MsgField
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
    }
}
