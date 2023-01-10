using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Inventory
{
    public class AddCheckBoxToDataGridView
    {
        public static System.Windows.Forms.DataGridView dgv;
        private Dictionary<System.Windows.Forms.DataGridView, System.Windows.Forms.CheckBox> Dic = new Dictionary<System.Windows.Forms.DataGridView, System.Windows.Forms.CheckBox>();
        
 
        public static void AddFullSelect()
        {
            System.Windows.Forms.CheckBox ckBox = new System.Windows.Forms.CheckBox();
            ckBox.Text = "";
            ckBox.Checked = false;
            System.Drawing.Rectangle rect = dgv.GetCellDisplayRectangle(0, -1, true);
            ckBox.Size = new System.Drawing.Size(14, 14);
            //ckBox.Location = new Point(rect.Location.X + dgv.Columns[0].Width / 2 - 13 / 2 - 1, rect.Location.Y + 3);
            //ckBox.Location.Offset(-40, rect.Location.Y);  
            int x = dgv.Columns[0].Width / 2 - (14 / 2);
            int y = dgv.ColumnHeadersHeight / 2 - (14 / 2);
            ckBox.Location = new Point(x, y);
            ckBox.CheckedChanged += new EventHandler(ckBox_CheckedChanged);
            dgv.Controls.Add(ckBox);
        }
        static void ckBox_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = ((System.Windows.Forms.CheckBox)sender).Checked;
            }
            dgv.EndEdit();
        }  
    }
}
