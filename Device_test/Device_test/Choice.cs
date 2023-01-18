using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_test
{
    public partial class Choice : Form
    {
        public Choice()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OneDoorForm.START = 1;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Active.START = 1;
            this.Close();
        }
    }
}
