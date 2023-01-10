using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using PT;
using PsionTeklogix.Keyboard;
using PsionTeklogix;
using PsionTeklogix.Barcode;
using System.Threading;

namespace _1550PDA
{
    public partial class Form1 : Form
    {
        private string id = "";
        private string area = "";
        /// <summary>
        /// 接口
        /// </summary>
        /// <param name="_Truck"></param>
        public PT.PTInterfacePrx _Prx = null;
        /// <summary>
        /// 用户信息
        /// </summary>
        private dtPTCommon _people = new dtPTCommon();
        /// <summary>
        /// 通讯实例
        /// </summary>
        Ice.Communicator comm = null;

        public Form1(dtPTCommon people, PTInterfacePrx Prx)
        {
            InitializeComponent();
            textBox1.Focus();
            this.Load += new EventHandler(StockForm_Activated);
            this.Closed += new EventHandler(StockForm_Closed);
            _Prx = Prx;
            _people = people;
            listBox1.Items.Add("初始化成功。");
            listBox1.Items.Add("请开始你的表演。");
        }

        private void StockForm_Activated(object sender, EventArgs e)
        {
            ScannerHelper.RegisterWithScanner(ScannerHelper_ScanCompleteEvent);
            listBox1.Items.Add("扫描注册。");
        }
        private void StockForm_Closed(object sender, EventArgs e)
        {
            ScannerHelper.ScannerDestroy();

        }

        private delegate void OnScanCompleteDelegate(object sender, ScanCompleteEventArgs e);

        #region   void ScannerHelper_ScanCompleteEvent(object sender, ScanCompleteEventArgs e)  扫描完成事件
        /// <summary>
        /// 扫描完成事件
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        void ScannerHelper_ScanCompleteEvent(object Sender, PsionTeklogix.Barcode.ScanCompleteEventArgs e)
        {
            try
            {
                string tmp = e.Text.Trim().ToUpper();

                textBox1.Text = tmp;
                listBox1.Items.Add("手持机扫描到：");
                listBox1.Items.Add(textBox1.Text);
               
            }
            catch (System.Exception ex)
            {
                //Program.LogException(ex, true);
                //txtresult.Text = "材料扫描失败";
                //txtresult.BackColor = Color.Green;
                listBox1.Items.Add("材料扫描失败。");
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                listBox1.Items.Add("textBox1为空。");

            }
            else if (textBox1.Text != "")
            {
                listBox1.Items.Add(string.Format("输入文本为：{0}", textBox1.Text));
            }
            this.Activated += new EventHandler(StockForm_Activated);
            this.Closed += new EventHandler(StockForm_Closed);
        }

        private void btnRet_Click(object sender, EventArgs e)
        {
            try
            {
                
                btnRedo_Click(null, null);
                //Prx.OutInventoryInfo(people.StoreID, out id, out area, Program.ctx);
                //Prx.OutInventoryInfo("Z32", out id, out area);
               // people.StoreID = "Z32-1";
                _Prx.OutInventoryInfo(_people.StoreID, out id, out area);
                listBox1.Items.Add("盘库开始。");
                //txtresult.Text = "盘库区域：" + area;
                //people.sqare1 = id;
            }
            catch (Ice.Exception ex)
            {
                listBox1.Items.Add( "访问超时");
            }
            catch (System.Exception ex)
            {
                listBox1.Items.Add("盘库开始失败");
                listBox1.Items.Add(ex.Message);
            }

        }
        private void btnRedo_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("清空数据");
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ////本机IP号后三位，作为手持机编号
            //string hostName = System.Net.Dns.GetHostName();
            //System.Net.IPHostEntry localhost = System.Net.Dns.GetHostEntry(hostName);
            //System.Net.IPAddress IP = localhost.AddressList[0];
            //_people.PTID = IP.ToString().Substring(IP.ToString().Length - 3, 3);

            //comm = Ice.Util.initialize();
            //comm.getProperties().load(Program.Location + "\\config.txt");

            //// 本机IP隐式传递
            //Program.ctx["IP_ADDR"] = IP.ToString();
            //Ice.ObjectPrx myprx = comm.propertyToProxy("PDA.Proxy");
            //_Prx = PT.PTInterfacePrxHelper.uncheckedCast(myprx);
        }


    }
}