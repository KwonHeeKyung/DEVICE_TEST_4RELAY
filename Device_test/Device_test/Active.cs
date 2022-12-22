using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_test
{
    public partial class Active : Form
    {
        public static int START = 0;

        
        Scanner sc;
        Door door;

        public Active()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 1024;
            this.FormBorderStyle = FormBorderStyle.None;

            door1_open.Visible = false;
            door2_open.Visible = false;
            sc = new Scanner();
            sc.DataRecvHandler = ScannerStatus;
            sc.open();
            door = new Door();
            door.DataRecvHandler = DoorStatus;
            door.open();
            door.Data_send("T");

        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                door.Data_send("F");
                sc.close();
                door.close();
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }
            
        }

        private void ScannerStatus(byte[] data)
        {
            if(tb_scanner.InvokeRequired)
            {
                Action write = delegate { ScannerStatus(data); };
                tb_scanner.Invoke(write);
                
            }
            else
            {
                tb_scanner.Text = Encoding.Default.GetString(data);
            }
            
        }
        private void DoorStatus(byte[] data)
        {
            string status = Encoding.Default.GetString(data);
            string[] arr = status.Split(',');

            if (arr.Length > 1)
            {
                if (arr[0] == "c")
                {
                    DoorVisible(door1_close, true);
                    DoorVisible(door1_open, false);
                }
                else if (arr[0] == "o")
                {

                    DoorVisible(door1_close, false);
                    DoorVisible(door1_open, true);
                }

                if (arr[1] == "c")
                {
                    DoorVisible(door2_close, true);
                    DoorVisible(door2_open, false);
                }
                else if (arr[1] == "o")
                {
                    DoorVisible(door2_close, false);
                    DoorVisible(door2_open, true);
                }
            }
            
        }

        private void DoorVisible(Button btn, bool visible)
        {
            Action action = delegate { DoorVisible(btn, visible); };
            if (btn.InvokeRequired)
            {
                btn.Invoke(action);
            }
            else
            {
                btn.Visible = visible;
            }
        }

        private void btn_relay1_Click(object sender, EventArgs e)
        {
            door.Data_send("1");
        }

        private void btn_relay2_Click(object sender, EventArgs e)
        {
            door.Data_send("4");
        }

        private void btn_relay3_Click(object sender, EventArgs e)
        {
            door.Data_send("3");
        }

        private void btn_relay4_Click(object sender, EventArgs e)
        {
            door.Data_send("5");
        }

        private void btn_power1_on_Click(object sender, EventArgs e)
        {
            door.Data_send("6");
        }

        private void btn_power1_off_Click(object sender, EventArgs e)
        {
            door.Data_send("7");
        }

        private void btn_power2_on_Click(object sender, EventArgs e)
        {
            door.Data_send("8");
        }

        private void btn_power2_off_Click(object sender, EventArgs e)
        {
            door.Data_send("9");
        }
    }
}
