using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MODULES_OF_PREMIERE
{
    public class XComMessage0
    {
        private short textLenth;

        public short TextLenth
        {
            get { return textLenth; }
            set { textLenth = value; }
        }


        private short lineno;

        public short Lineno
        {
            get { return lineno; }
            set { lineno = value; }
        }


        String messageNO;

        public String MessageNO
        {
            get { return messageNO; }
            set 
            { 
                messageNO = value;
                if (messageNO.Length > 12)
                {
                    messageNO.Substring(0, 12);
                }

                for (int i = 0; i < 12; i++)
                {
                    byteMessageNO[i] = 0x00;
                }

                byte[] bytesTemp=System.Text.Encoding.ASCII.GetBytes(messageNO);

                for (int i = 0; i < messageNO.Length; i++)
                {
                    byteMessageNO[i] = bytesTemp[i];
                }
            }
        }
        private byte[] byteMessageNO = new byte[12];



        String textBuf;	

        public String TextBuf
        {
            get { return textBuf; }
            set { textBuf = value; }
        }

        public byte[] Code2Bytes()
        {
            List<byte> listBytes = new List<byte>();
            try
            {
                listBytes.AddRange(BitConverter.GetBytes(textLenth));       //2bytes
                listBytes.AddRange(BitConverter.GetBytes(lineno));       //2bytes


                listBytes.AddRange(byteMessageNO);

                listBytes.AddRange(System.Text.Encoding.ASCII.GetBytes( textBuf ) );

                byte[] byteEnd= new byte[1];
                byteEnd[0] = 0x00;
                listBytes.AddRange(byteEnd);
            }
            catch (Exception ex)
            {
            }
            byte[] byteArray = new byte[listBytes.Count];
            listBytes.CopyTo(byteArray);
            return byteArray;
        }
    }
}
