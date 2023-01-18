using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Device_test
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
            Application.Run(new Choice());
            if(OneDoorForm.START == 1)
            {
                Application.Run(new OneDoorForm());
            }
            else if(Active.START == 1)
            {
                Application.Run(new Active());
            }
            
            
        }
    }
}
