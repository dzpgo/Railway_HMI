using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Baosight.iSuperframe.Forms;
using Baosight.iSuperframe.TagService;
using System.Threading;
using ParkClassLibrary ;

namespace UACSParking
{
    //public class LogManager
    //{
    //    static object locker = new object();
    //    /// <summary>
    //    /// 重要信息写入日志
    //    /// </summary>
    //    /// <param name="logs">日志列表，每条日志占一行</param>
    //    public static void WriteProgramLog(params string[] logs)
    //    {
    //        lock (locker)
    //        {
    //            string LogAddress = Environment.CurrentDirectory + "\\Log";
    //            if (!Directory.Exists(LogAddress + "\\RFIDClien"))
    //            {
    //                Directory.CreateDirectory(LogAddress + "\\RFIDClien");
    //            }
    //            LogAddress = string.Concat(LogAddress, "\\RFIDClien\\", "RFIDClien.log");
    //             //DateTime.Now.Year, '-', DateTime.Now.Month, '-',
    //             //DateTime.Now.Day, "_RFIDClien.log");
    //            StreamWriter sw = new StreamWriter(LogAddress, true);
    //            foreach (string log in logs)
    //            {
    //                sw.WriteLine(string.Format("[{0}] {1}", DateTime.Now.ToString(), log));
    //            }
    //            sw.Close();

    //        }
    //    }
    //}
    public partial class RFIDClien : Baosight.iSuperframe.Forms.FormBase
    {
        Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDP = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();
        //Baosight.iSuperframe.TagService.Controls.TagDataProvider tagDPrefresh = new Baosight.iSuperframe.TagService.Controls.TagDataProvider();

        Baosight.iSuperframe.TagService.DataCollection<object> TagValues = new Baosight.iSuperframe.TagService.DataCollection<object>();
        Baosight.iSuperframe.TagService.DataCollection<object> outData = new DataCollection<object>();
        const string TAG_DAOZHA_A_NORTH_CLOSE = "DAOZHA_A_NORTH_CLOSE";
        string[] strsTagName = { TAG_DAOZHA_A_NORTH_CLOSE };
        //// Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        #region 数据库连接
        private static Baosight.iSuperframe.Common.IDBHelper dbHelper = null;
        //连接数据库
        private static Baosight.iSuperframe.Common.IDBHelper DBHelper
        {
            get
            {
                if (dbHelper == null)
                {
                    try
                    {
                        dbHelper = Baosight.iSuperframe.Common.DataBase.DBFactory.GetHelper("ZJ1550");//平台连接数据库的Text
                    }
                    catch (System.Exception er)
                    {
                        MessageBox.Show(er.Message);
                    }
                }
                return dbHelper;
            }
        }
        #endregion
        Socket client = null;

        RFIDCar rfidcar = new RFIDCar();
        CarInfo currcar ;

        string curCarNO = "";
        string mCurCarNO = "";
        string currGate = "";
        //string doorDrection = "";
        bool isComing = false;
        int count = 1000;
        public RFIDClien()
        {
            InitializeComponent();
        }

        void ShowMsg(string msg)

        {

            txtInfo.AppendText(msg + "\r\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //连接到的目标IP
            IPAddress ip = IPAddress.Parse(txtIP.Text.Trim());
            //连接到目标IP的哪个应用(端口号！)
            IPEndPoint point = new IPEndPoint(ip, int.Parse(txtPort.Text.Trim()));

            try
            {
                //连接到服务器
                client.Connect(point);
                txtInfo.AppendText("连接成功\r\n");
                txtInfo.AppendText("服务器:" + client.RemoteEndPoint.ToString() + "\r\n");
                txtInfo.AppendText("客户端:" + client.LocalEndPoint.ToString() + "\r\n");
                txtInfo.AppendText("版本号ZJFT 1.0"  + "\r\n");
                //连接成功后，就可以接收服务器发送的信息了 

                //Thread th = new Thread(ReceiveMsg);
                Thread th = new Thread(ReceiveMsgNewByTime);
                th.IsBackground = true;
                th.Start();

                btnConnect.Enabled = false;
               

            }
            catch (Exception ex)
            {
                txtInfo.AppendText(ex.Message);
            }
        }
     
        private void ReceiveMsgNewByTime()
        {
            string mCurrTag = "";
            string mCurrPortID = "";
            string mCurrGate = "";
            try
            {
                txtInfo.AppendText(string.Format("this.IsDisposed= {0}, 开始接收.....\r\n", this.IsDisposed.ToString()));
                while (!this.IsDisposed)
                {
                    byte[] buffer = new byte[1024];
                    int n = client.Receive(buffer);
                    string s = Encoding.UTF8.GetString(buffer, 0, n);
                    DateTime dataTimeStart = DateTime.Now;
                    txtInfo.AppendText("\r\n"+ DateTime.Now.ToLongTimeString() + ": \r\n数据处理开始........\r\n");
                    //logger.Info(s);
                    //接收RFID Server数据
                    #region 保存日志
                    if (count == 9999)
                    {
                        count = 1000;
                        //保存到日志文件中去。
                        try
                        {
                            //string filename = DateTime.Now.ToString("yyyyMMddHHmmss")+ ".txt";
                            //File.WriteAllText(filename, txtInfo.Text);
                            //txtInfo.Text = "";
                            //txtInfo.AppendText("\r\n保存日志文件\r\n");

                        }
                        catch (IOException e)
                        {
                            MessageBox.Show(e.Message);
                        }
                    }
                    #endregion
                    txtInfo.AppendText(count.ToString() + " " + DateTime.Now.ToLongTimeString() + "--" + client.RemoteEndPoint.ToString() + ":" + s + "\r\n");

                    #region 删除显示文本
                    count++;
                    if (count > 1200)
                    {
                        txtInfo.Text = "";
                        count = 1000;
                    }
                    #endregion
                    //道闸控制
                    //拆分数据
                    if (rfidcar.getTagInfo(s, out mCurrTag, out mCurrPortID, out mCurCarNO, out mCurrGate))
                    {
                        txtInfo.AppendText("CurrTag = " + mCurrTag + ", CurrPortID = " + mCurrPortID + ",CurCarNO = " + mCurCarNO + ", CurrGate =" + mCurrGate + "\r\n");
                        GateControl_NEW(mCurrTag, mCurrPortID, mCurrGate); 
                    }
                    else
                    {
                        txtInfo.AppendText(string.Format("...没有车辆出入信号...................\r\n"));
                    }
                    TimeSpan span = DateTime.Now.Subtract(dataTimeStart); 
                    double sec = span.TotalSeconds;
                    txtInfo.AppendText(DateTime.Now.ToLongTimeString() + " : 处理结束，共耗时："+ sec + "秒.\r\n");
                }


            }
            catch (Exception)
            {

            }
        }
        /// <summary>
        /// 控制道闸方法
        /// </summary>
        /// <param name="Msg"></param>
        private bool GateControl_NEW(string tagID,string portID,string currDoor)
        {
            bool ret = false;
            try
            {
                double sec = 0;
                //检验是否已经响应
                if (rfidcar.PassGateLess60s(tagID, currDoor, out sec))
                {
                    txtInfo.AppendText(string.Format("----------当前车：{0}  信号已处理，相差: {1} 秒 --------\r\n", mCurCarNO , sec));
                    ret = true;
                    return ret;
                }

                //更新车信息
                string info = rfidcar.UpdataCars(tagID, portID, currDoor, out currcar);
                txtInfo.AppendText( "\r\n"+ DateTime.Now.ToLongTimeString() + ":" + info + "\r\n");
                if (currcar == null)
                {
                    return ret;
                }
                ret = true;
                //出入库类型
                if (currcar.CarStatus == 1)
                {
                    //推荐车位 ，LED显示
                    txtInfo.AppendText("------------------入库-----------------\r\n");
                }
                else
                {
                    //LED刷新
                    txtInfo.AppendText("------------------出库-----------------\r\n");
                }
                //发Tag
                StringBuilder sb = new StringBuilder("1");
                sb.Append("|");
                sb.Append(currcar.CarID);
                sb.Append("|");
                sb.Append(currcar.CarStatus);
                string tagVaule = sb.ToString();
                //txtInfo.AppendText("当前道闸 = " + currcar.Door + "\r\n");
                if (currcar.Door ==  CarInfo.A_GATE_S)
                {
                    tagDP.SetData("DAOZHA_A_SOUTH_OPEN", tagVaule);  //tagvaule :1|CarID|carStatus
                    txtInfo.AppendText(string.Format("\r\ndebug：DAOZHA_A_SOUTH_OPEN,{0}\r\n", tagVaule));
                    Thread.Sleep(1030);
                    tagDP.SetData("DAOZHA_A_SOUTH_OPEN", "0");
                }
                else if (currcar.Door == CarInfo.A_GATE_N)
                {
                    tagDP.SetData("DAOZHA_A_NORTH_OPEN", tagVaule);
                    txtInfo.AppendText(string.Format("\r\ndebug：DAOZHA_A_NORTH_OPEN,{0}\r\n", tagVaule));
                    Thread.Sleep(1030);
                    tagDP.SetData("DAOZHA_A_NORTH_OPEN", "0");
                }
                else if (currcar.Door == CarInfo.C_GATE_N)
                {
                    tagDP.SetData("DAOZHA_C_NORTH_OPEN", tagVaule);
                    txtInfo.AppendText(string.Format("\r\ndebug：DAOZHA_C_NORTH_OPEN,{0}\r\n", tagVaule));
                    Thread.Sleep(1030);
                    tagDP.SetData("DAOZHA_C_NORTH_OPEN", "0");
                }
                else if (currcar.Door == CarInfo.C_GATE_S)
                {
                    tagDP.SetData("DAOZHA_C_SOUTH_OPEN", tagVaule);  //tagvaule :1|CarID|carStatus
                    txtInfo.AppendText(string.Format("\r\ndebug：DAOZHA_C_SOUTH_OPEN,{0}\r\n", tagVaule));
                    Thread.Sleep(1030);
                    tagDP.SetData("DAOZHA_C_SOUTH_OPEN", "0");
                }
                txtInfo.AppendText("----------------数据发送后台成功----------------\r\n");
                string temp = currcar.CarStatus == 1 ? "IN" : "OUT";
                insertHistory(currcar.CarID, currcar.CarLicence, temp, currcar.Door);
                txtInfo.AppendText("-------写入数据库.................------\r\n");
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
            return ret;
        }
        
        
        /// <summary>
        /// 车离开
        /// </summary>
        private void CarLeaveGate()
        {

            if (currGate == "S")
            {
                tagDP.SetData("DAOZHA_A_SOUTH_OPEN", "0");
                //tagDP.SetData("DAOZHA_A_SOUTH_CLOSE", "1");
            }
            else
            {
                tagDP.SetData("DAOZHA_A_NORTH_OPEN", "0");
                //tagDP.SetData("DAOZHA_A_NORTH_CLOSE", "1");
            }
            currGate = "";
            txtInfo.AppendText("--------车离开道闸....tagDP.SetData--0--\r\n");
        }
        /// <summary>
        /// 相同道闸的返回true
        /// </summary>
        /// <param name="ID1"></param>
        /// <param name="ID2"></param>
        /// <returns></returns>
        private bool ComparePortID(string ID1,string ID2)
        {
            bool ret=false;
            try
            {
                string n_str = "5011,5012";
                string s_str = "5013,5014";
                if (n_str.Contains(ID1)&& n_str.Contains(ID2))
                {
                    ret = true;
                }
                else if (s_str.Contains(ID1) && s_str.Contains(ID2))
                {
                    ret = true;
                }
               
            }
            catch (Exception)
            {
                
            }

            return ret;
        }
        /// <summary>
        /// 相同门的返回true
        /// </summary>
        /// <param name="ID1"></param>
        /// <param name="ID2"></param>
        /// <returns></returns>
        private bool CompareGate(string gate)
        {
            bool ret = false;
            try
            {
                //if (gate == "N")
                //{
                //    ret = curCar_North.Door == gate ? true : false;
                //}
                //else if (gate == "S")
                //{
                //    ret = currCar_South.Door == gate ? true : false;
                //}
            }
            catch (Exception)
            {

            }

            return ret;
        } 
        private void Form1_Load(object sender, EventArgs e)
        {
            tagDP.ServiceName = "iplature";
            tagDP.AutoRegist = true;
            TagValues.Clear();
            TagValues.Add("DAOZHA_A_NORTH_CLOSE", null);
            tagDP.Attach(TagValues);
            //tagDP.DataChangedEvent += tagDP_DataChangedEvent;

            CheckForIllegalCrossThreadCalls = false;
           // this.FormClosed += RFIDClien_FormClosed;

            //timer1.Start();
            //TAG刷新
            //string[] tagname = new string[] { TAG_DAOZHA_A_NORTH_CLOSE };
            //tagDPrefresh.ServiceName = "iplature";
            //tagDPrefresh.RegisterData(new Guid(), tagname);
            //tagDPrefresh.DataChangedEvent += tagDPrefresh_DataChangedEvent;
            timer1.Interval = 3000;
            timer1.Start();
        }

       

        void tagDP_DataChangedEvent()
        {
            tagDP.GetData(strsTagName, out outData);
            string temp = outData[TAG_DAOZHA_A_NORTH_CLOSE].ToString();
            string[] strs;
            string carNO ="";
            string status ="";
            if (temp.Contains("|"))
            {
                strs = temp.Split('|');
            }
            else
            {
                return;
            }
            if (strs.Length==3)
            {
                carNO = strs[1];
                status = strs[2];
            }
            if (carNO !="" && status !="")
            {
                if (carNO =="ALL")
                {
                    string info = rfidcar.CarStateClear();
                    txtInfo.AppendText("状态清空:\r\n");
                    txtInfo.AppendText(info + "\r\n");
                }
                else
                {
                    string strInfo = rfidcar.ChangeCarStatus(carNO,int.Parse(status));
                    txtInfo.AppendText(strInfo);
                }
                tagDP.SetData(TAG_DAOZHA_A_NORTH_CLOSE, "0");
            }
        }

        void RFIDClien_FormClosed(object sender, FormClosedEventArgs e)
        {
            txtInfo.Text = "";
            if (client != null)
            {
                client.Close();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDisConnect_Click(object sender, EventArgs e)
        {
            // client.Disconnect();
            /*
            client.Disconnect(true);

            btnConnect.Enabled = true;
            btnDisConnect.Enabled = false;

            timer1.Stop();
            */
        }

        /// <summary>
        /// 修改RFID状态，在库区内还是库区外
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            //string tagID = comboBox1.Text.Trim();

            //if (tagID == "")
            //    return;

            //string strStatus = comboBox2.Text;

            //if (strStatus.IndexOf('0') >= 0)
            //    rfidcar.ModifyTagStatus(tagID, 0);

            //if (strStatus.IndexOf('1') >= 0)
            //    rfidcar.ModifyTagStatus(tagID, 1);

            //if (strStatus.IndexOf("-1") >= 0)
            //    rfidcar.ModifyTagStatus(tagID, -1);
            string carNo = txtCarNO.Text;
            int carStatus = comboBox2.Text.Contains("1") ? 1: 0;

           string strInfo = rfidcar.ChangeCarStatus(carNo, carStatus);
           txtInfo.AppendText(strInfo);
        }

        /// <summary>
        /// 定周期更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            tagDP_DataChangedEvent();
        }

        private void btnNOppen_Click(object sender, EventArgs e)
        {
            tagDP.SetData("DAOZHA_A_NORTH_OPEN", "1");
            Thread.Sleep(1000);
            tagDP.SetData("DAOZHA_A_NORTH_OPEN", "0");
        }

        private void btnNClose_Click(object sender, EventArgs e)
        {
            tagDP.SetData("DAOZHA_A_NORTH_CLOSE", "1");
            Thread.Sleep(1000);
            tagDP.SetData("DAOZHA_A_NORTH_CLOSE", "0");
        }

        private bool  FindCarByTag(string tag, out string carNO, out string carNumber)
        {
            bool  ret = false;
            try
            {
                //
                string sqlText = @"SELECT COUNT(CARNO) AS COUNT FROM UACS_CAR_HEAD_DEFINE WHERE CAR_TAG_NUM LIKE  '%" + tag + "%'";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        if (rdr["COUNT"].ToString() != "1")
                        {
                            ret = true; 
                        }
                    } 
                }
                string sqlTextF = @"SELECT CARNO,CAR_NUMBER FROM UACSAPP.UACS_CAR_HEAD_DEFINE WHERE CAR_TAG_NUM LIKE  '%" + tag + "%'";

                using (IDataReader rdr = DBHelper.ExecuteReader(sqlTextF))
                {
                    while (rdr.Read())
                    {
                        if (rdr["CARNO"] != DBNull.Value)
                        {
                            carNO = Convert.ToString(rdr["CARNO"]);
                        }
                        if (rdr["CAR_NUMBER"] != DBNull.Value)
                        {
                            carNO = Convert.ToString(rdr["CAR_NUMBER"]);
                        }
                    }
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message + "\r\n" + er.StackTrace);
            }
            carNO = "";
            carNumber = "";
            return ret;
        }

        private void btnSOpen_Click(object sender, EventArgs e)
        {
            tagDP.SetData("DAOZHA_A_SOUTH_OPEN", "1");
            txtInfo.AppendText(string.Format("手动置1 {0}\r\n", DateTime.Now.Second));
            Thread.Sleep(1000);
            tagDP.SetData("DAOZHA_A_SOUTH_OPEN", "0");
            txtInfo.AppendText(string.Format("手动置0 {0}\r\n", DateTime.Now.Second));
        }

        private void btnSClose_Click(object sender, EventArgs e)
        {
            tagDP.SetData("DAOZHA_A_SOUTH_CLOSE", "1");
            Thread.Sleep(1000);
            tagDP.SetData("DAOZHA_A_SOUTH_CLOSE", "0");
        }

        private void RFIDClien_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (client != null)
                {
                    client.Close();
                }
                //base.OnVisibleChanged(e);
                //if (!IsHandleCreated)
                //{
                //    this.Close();
                //}
                //Thread.CurrentThread.Abort();
            }
            catch (Exception)
            {
                
                
            }
        }

        private void btnCarStatusSet0_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定要清空所有车状态？", "提示", MessageBoxButtons.OKCancel,MessageBoxIcon.Asterisk );
            if (dr == DialogResult.Cancel)
            {
                this.Close();
                return;
            }
           string info =  rfidcar.CarStateClear();
           txtInfo.AppendText("状态清空:\r\n");
           txtInfo.AppendText(info + "\r\n");
        }

        private void insertHistory(string carNO, string carLicence ,string action ,string gate)
        {
            try
            {
                string sql = @"INSERT INTO UACS_CAR_INOUT_HISTORY (
                   SEQUENCE
                  ,CARNO
                  ,CAR_NUMBER
                  ,IN_OUT
                  ,IN_OUT_TIME
                  ,GATE_FLAGE
                ) VALUES (";

                sql += "1";
                sql += " ,'" + carNO + "'";
                sql += " ,'" + carLicence + "'";
                sql += " ,'" + action + "'";
                sql += ",NULL";
                sql += " ,'" + gate + "'";
                sql += " )";
                ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }


    }
}
