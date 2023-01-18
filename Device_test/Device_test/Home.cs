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
    public partial class Home : Form
    {
        private string text = "";
        private string PASSWORD = "4240";
        public Home()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 1024;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void check()
        {
            if (text.Equals(PASSWORD)) {
                Console.WriteLine("OK");
                this.Close();
                
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            string num = ((Button)sender).Text;
            if(num.Equals("OK"))
            {
                check();
            }
            else if (num.Equals("C")){
                text = "";
            }
            else
            {
                text += ((Button)sender).Text;
                check();
            }
            
        }

    }
}
