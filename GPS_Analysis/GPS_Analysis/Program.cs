using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GPS_Analysis
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            programInitial();
            Application.Run(new Form1());
        }
        private static void programInitial()
        {
            object o = nsConfigDB.ConfigDB.getConfig("serialport");
            if (o != null)
            {
                staticClass.serialport_name = o as string;
                //staticClass.restServerIP = o.ToString();
            }


        }
    }
}
