using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UACSParking
{
    public partial class CarNo : Form
    {
        public string Area = "空";
        private string[] areaList = { "京", "津", "沪", "渝", "冀", "豫", "云", "辽", "黑", "湘", "皖", "鲁",
        "新", "苏", "浙", "赣", "鄂", "桂", "甘", "晋", "蒙", "陕", "吉","闽", "贵", "粤", "青", "藏", "川",
            "宁", "琼", "湛钢", "空"};
        public CarNo()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            try
            {
                Area = ((Button)sender).Tag.ToString();
                this.Close();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
            
        }

        private void CarNo_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            try
            {
                int x = 0;
                int y = 0;
                for (int i=0;i<areaList.Length;i++)
                {
                    if (12 + (x+1) * 60 > this.Width)
                    {
                        x = 0;
                        y++;
                    }
                    int locationX = 12 + x * 60;
                    int locationY = 12 + y * 50;
                    Button btn = new Button();
                    btn.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    btn.Location = new System.Drawing.Point(locationX, locationY);
                    btn.Name = "btn"+i;
                    btn.Size = new System.Drawing.Size(60, 40);
                    btn.TabIndex = 0;
                    btn.Tag = areaList[i];
                    btn.Text = areaList[i];
                    btn.UseVisualStyleBackColor = true;
                    btn.Click += new System.EventHandler(this.button_Click);
                    this.Controls.Add(btn);
                    x++;
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
