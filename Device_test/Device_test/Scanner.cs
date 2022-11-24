using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Schema;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Device_test
{
    internal class Scanner
    {
        #region ini 입력 메소드
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        #endregion

        SerialPort ser = new SerialPort();
        StringBuilder _scanner = new StringBuilder();
        public delegate void DataRecvHandlerFunc(byte[] data);
        public DataRecvHandlerFunc DataRecvHandler;

        public Scanner()
        {
            // ini파일에서 데이터를 불러옴
            // GetPrivateProfileString("카테고리", "Key값", "기본값", "저장할 변수", "불러올 경로");
            Console.WriteLine(Application.StartupPath);
            GetPrivateProfileString("refrigerators", "scanner", "", _scanner, 32, Application.StartupPath + @"\config.ini");

        }

        public bool open()
        {
            try
            {
                ser.PortName = _scanner.ToString();
                ser.BaudRate = 38400;
                ser.DataBits = 8;
                ser.StopBits = StopBits.One;
                ser.Parity = Parity.None;

                ser.DataReceived += Data_recv;

                ser.Open();
                return true;
            }
            catch (Exception ex){
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public void close()
        {
            try
            {
                ser.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("SCANNER ERROR");
            }
            
        }

        private byte[] ReadSerialByteData()
        {
            ser.ReadTimeout = 100;
            byte[] bytesBuffer = new byte[ser.BytesToRead];
            int bufferOffset = 0;
            int bytesToRead = ser.BytesToRead;

            while (bytesToRead > 0)
            {
                try
                {
                    int readBytes = ser.Read(bytesBuffer, bufferOffset, bytesToRead - bufferOffset);
                    bytesToRead -= readBytes;
                    bufferOffset += readBytes;
                }
                catch (TimeoutException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            return bytesBuffer;
        }

        private void Data_recv(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                byte[] bytesBuffer = ReadSerialByteData();
                string strBuffer = Encoding.ASCII.GetString(bytesBuffer);

                if (bytesBuffer.Length > 0)
                {
                    DataRecvHandler(bytesBuffer);

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
    
}
