using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using ParkClassLibrary;

namespace UACSParking
{
    public partial class SubFrmSelectStowageType : Form
    {
        public SubFrmSelectStowageType()
        {
            InitializeComponent();
            this.Load += SubFrmSelectStowageType_Load;
        }
        ClsParkingManager clsParkManager = new ClsParkingManager();
        private string railwayLineNO;

        public string RailwayLineNO
        {
            get { return railwayLineNO; }
            set { railwayLineNO = value; }
        }
        private string trainCaseNO; //车皮号

        public string TrainCaseNO
        {
            get { return trainCaseNO; }
            set { trainCaseNO = value; }
        }
        private string specification; //规格(车皮类型)

        public string Specification
        {
            get { return specification; }
            set { 
                specification = value;
                switch(specification)
                {
                    case ClsParkingManager.TRAIN_SPECIFICATION_C60:
                        picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C60";
                        groupBox1.Text = "60吨方案（C60）";
                        break;
                    case ClsParkingManager.TRAIN_SPECIFICATION_C70  :
                        picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C70";
                        groupBox1.Text = "70吨方案（C70）";
                        break;

                    case ClsParkingManager.TRAIN_SPECIFICATION_C60_1:
                        picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C60_1";
                        groupBox1.Text = "睿力60吨方案（C60）";
                        break;
                    case ClsParkingManager.TRAIN_SPECIFICATION_C70_1:
                        picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C70_1";
                        groupBox1.Text = "睿力70吨方案（C70）";
                        break;
                    case ClsParkingManager.TRAIN_SPECIFICATION_C71_1:
                        picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C70_1";
                        groupBox1.Text = "睿力71吨方案（C71）";
                        break;
                    default:
                        groupBox1.Text = "60吨方案（C60）";
                        picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C60";
                        break;

                }
                     

                //if (specification==ClsParkingManager.TRAIN_SPECIFICATION_C70 )
                //{
                //    picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C70";
                //    groupBox1.Text = "70吨方案（C70）";
                //}
                //else
                //{
                //    groupBox1.Text = "60吨方案（C60）";
                //    picPath = @"C:\iPlature\SF_HOME\app\form\TrainStowageScheme_C60";
                //}
               }
        }
        private string selectedStowage = "";

        public string SelectedStowage
        {
            get { return selectedStowage; }
            set { selectedStowage = value; }
        }
        private string stowageName;

        public string StowageName  //配载名称，给后台的
        {
            get { return stowageName; }
            set { stowageName = value; }
        }
        string selectingStowage = "";
        private bool Pflag;

        int flag = 0;                                                                          //记录当前是第几张图片
        FileSystemInfo[] fsinfo;                                                         //存储遍历文件夹后的文件
        ArrayList al = new ArrayList();                                                      //数组变量存储图片路径
        int MM = 0;
        string picPath; //= @"E:\UACSFlies\铁路库\铁路配载方案图";
        void SubFrmSelectStowageType_Load(object sender, EventArgs e)
        {
            bindlstItem(listBox1);
            LoadStowagePicture(picPath);
            listBox1_SelectedIndexChanged(null, null);
        }
        //加载图片
        private void LoadStowagePicture(string path)
        {
            try
            {
                al.Clear();                                                               //清空集合
                //listBox1.Items.Clear();                                                    //清空控件
                // txtPicPath.Text = folderBrowserDialog1.SelectedPath;                     //获取选择的文件夹路径
                DirectoryInfo di = new DirectoryInfo(path);                   //创建DirectoryInfo实例
                fsinfo = di.GetFileSystemInfos();                                            //获取目录下文件
                for (int i = 0; i < fsinfo.Length; i++)                                               //遍历目录下所有文件
                {
                    string filename = fsinfo[i].ToString();                                      //获取文件路径
                    //获取文件类型
                    string filetype = filename.Substring(filename.LastIndexOf(".") + 1, filename.Length - filename.LastIndexOf(".") - 1);
                    filetype = filetype.ToLower();                                                 //类型小写
                    //if (filetype == "jpeg" || filetype == "jpg" || filetype == "png" || filetype == "gif" || filetype == "bmp")
                    if (filetype == "png")
                    {
                        listBox1.Items.Add(fsinfo[i].ToString().Substring(0, this.fsinfo[i].ToString().LastIndexOf(".")));                          //如果文件符合图片的类型则添加到控件中
                        al.Add(fsinfo[i].ToString());                                     //同时添加到集合中
                        flag++;                                                            //变量flag自增，记录切换的数量
                    }
                }

                listBox1.SetSelected(0, true);                                                   //设置第一项被选中
                listBox1.Focus();                                                            //ListBox控件获取焦点
                tssltotel.Text = "共有" + flag + "方案";                                    //显示当前是第几张图片
                Pflag = true;
            }
            catch (Exception)
            {
                
               
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string checkedText = listBox1.Text.ToString();
            string picturePath = picPath + "\\" + checkedText + ".png";
            if (File.Exists(picturePath ))
            {
                Image stowageImage = Image.FromFile(picturePath);
                pictureBox1.Width = stowageImage.Width;
                pictureBox1.Height = stowageImage.Height;
                pictureBox1.Image = stowageImage;
            }

            //selectingStowage = this.listBox1.SelectedItem.ToString();
            selectingStowage = this.listBox1.SelectedValue.ToString();
            tssltotel.Text = "选择方案：" + selectingStowage;
        }
        private void bindlstItem(ListBox lstbox)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("TypeValue");
            dt.Columns.Add("TypeName");
            try
            {
                string sqlText = "";
               
                if (specification.Contains('_'))
                {
                    sqlText = @"SELECT  DISTINCT STOWAGE_DEFINE  as TypeName ,STOWAGE_NAME as TypeValue
                              FROM UACS_RAILWAY_STOWAGE_ID_DEFINE WHERE  STOWAGE_NAME LIKE 'XFA%'  ORDER BY STOWAGE_NAME";
                }
                else
                {
                    sqlText = @"SELECT  DISTINCT STOWAGE_DEFINE  as TypeName ,STOWAGE_NAME as TypeValue
                             FROM UACS_RAILWAY_STOWAGE_ID_DEFINE WHERE  STOWAGE_NAME LIKE 'FA%'  ORDER BY STOWAGE_NAME";
                }
                using (IDataReader rdr = ParkClassLibrary.ClsParkingManager.DBHelper.ExecuteReader(sqlText))
                {
                    while (rdr.Read())
                    {
                        DataRow dr = dt.NewRow();
                        dr["TypeValue"] = rdr["TypeValue"];
                        dr["TypeName"] = rdr["TypeName"];
                        dt.Rows.Add(dr);
                    }
                }
                lstbox.DataSource = dt;
                lstbox.DisplayMember = "TypeName";
                lstbox.ValueMember = "TypeValue";
                lstbox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0},{1}", ex.StackTrace.ToString(), ex.Message.ToString()));
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            selectingStowage = "";
            selectedStowage = "";
            this.Close();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            try
            {
                selectedStowage = listBox1.Text.ToString();
                //clsParkManager.getStowageName(selectingStowage, out stowageName);
                StowageName = selectingStowage;
                if (TrainCaseNO != null && selectedStowage!="")
                {
                    string tagValue = RailwayLineNO + "|" + TrainCaseNO + "|" + StowageName;//stowageName
                    //DialogResult dr = MessageBox.Show("是否发送tagVaule： " + tagValue, "调试", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                    //if (dr != DialogResult.OK)
                    //{
                    //    return;
                    //}
                    ClsParkingManager.TagDP.SetData(ClsParkingManager.TAG_EV_RAILWAY_CARGO_STOWAGE_MODIFY, tagValue);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("信息不完整，提交失败！");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }
    }
}
