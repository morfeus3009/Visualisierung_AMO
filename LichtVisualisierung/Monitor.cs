using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visualisierung
{
    public partial class Monitor : Form
    {

        public string text { get; set; }

        public Monitor()
        {
            InitializeComponent();
        }

        public void monitorAddText()
        { 
            
        }

        private void Monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
                e.Cancel = false;
            else
                e.Cancel = true;
            //this.Hide();
            //this.Visible = false;
            CloseMonitor();
        }

        private void btnCloseMonitor_Click(object sender, EventArgs e)
        {
            CloseMonitor();
            //this.Hide();
        }

        private void CloseMonitor()
        {
            this.Hide();
        }

        //private void Monitor_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    CloseMonitor();
        //}
    }
}
