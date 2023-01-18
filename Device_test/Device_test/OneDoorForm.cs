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
    public partial class OneDoorForm : Form
    {
        public static int START = 0;
        Scanner sc;
        Door door;
        public OneDoorForm()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 1024;
            this.FormBorderStyle = FormBorderStyle.None;
            door1_open.Visible = false;
            sc = new Scanner();
            sc.DataRecvHandler = ScannerStatus;
            bool res = sc.open();
            
            door = new Door();
            door.DataRecvHandler = DoorStatus;
            res = door.open();
            if (res)
            {
                door.Data_send("T");
            }
            else
            {
                door1_close.Visible = false;
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            try
            {
                if (door.STATUS)
                {
                    door.Data_send("F");
                    door.close();
                    Console.WriteLine("Door Close");
                }

                if (sc.STATUS)
                {
                    sc.close();
                    Console.WriteLine("Scanner Close");
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR");
            }

        }

        private void ScannerStatus(byte[] data)
        {
            if (tb_scanner.InvokeRequired)
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

            if (status == "c")
            {
                DoorVisible(door1_close, true);
                DoorVisible(door1_open, false);
            }
            else if (status == "o")
            {

                DoorVisible(door1_close, false);
                DoorVisible(door1_open, true);
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

        private void btn_power1_on_Click(object sender, EventArgs e)
        {
            door.Data_send("6");
        }

        private void btn_power1_off_Click(object sender, EventArgs e)
        {
            door.Data_send("7");
        }

    }
}
