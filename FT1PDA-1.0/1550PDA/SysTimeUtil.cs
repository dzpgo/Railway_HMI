using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace _1550PDA
{
    [StructLayout( LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        public ushort wYear;
        public ushort wMonth;
        public ushort wDayOfWeek;
        public ushort wDay;
        public ushort wHour;
        public ushort wMinute;
        public ushort wSecond;
        public ushort wMilliseconds;
    }

    public class Kernel32TimeAPI
    {
        public static SYSTEMTIME FromDateTime(DateTime dateTime)
        {
            SYSTEMTIME sysTime;
            sysTime.wYear = (ushort)dateTime.Year;
            sysTime.wMonth = (ushort)dateTime.Month;
            sysTime.wDayOfWeek = (ushort)dateTime.DayOfWeek;
            sysTime.wDay = (ushort)dateTime.Day;
            sysTime.wHour = (ushort)dateTime.Hour;
            sysTime.wMinute = (ushort)dateTime.Minute;
            sysTime.wSecond = (ushort)dateTime.Second;
            sysTime.wMilliseconds = (ushort)dateTime.Millisecond;

            return sysTime;
        }

        public static DateTime ToDateTime(SYSTEMTIME sysTime)
        {
            return new DateTime(sysTime.wYear, sysTime.wMonth, sysTime.wDay, sysTime.wHour, sysTime.wMinute, sysTime.wSecond);
        }

        //设定，获取系统时间,SetSystemTime()默认设置的为UTC时间，比北京时间少了8个小时。
        [DllImport("Coredll.dll")]
        public static extern bool SetSystemTime(ref SYSTEMTIME time);
        [DllImport("Coredll.dll")]
        public static extern bool SetLocalTime(ref SYSTEMTIME time);
        [DllImport("Coredll.dll")]
        public static extern void GetSystemTime(ref SYSTEMTIME time);
        [DllImport("Coredll.dll")]
        public static extern void GetLocalTime(ref SYSTEMTIME time);
    }
}
