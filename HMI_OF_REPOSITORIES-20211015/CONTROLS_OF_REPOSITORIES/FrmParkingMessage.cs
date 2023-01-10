using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MODEL_OF_REPOSITORIES;

namespace CONTROLS_OF_REPOSITORIES
{
    public partial class FrmParkingMessage : Form
    {
        public AreaBase theAreaBase { get; set; }

        public FrmParkingMessage()
        {
            InitializeComponent();
            this.Load += FrmParkingMessage_Load;
        }

        void FrmParkingMessage_Load(object sender, EventArgs e)
        {
            
        }

       


    }
}
