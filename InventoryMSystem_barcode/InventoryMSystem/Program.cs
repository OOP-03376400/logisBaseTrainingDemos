using System;
using System.Collections.Generic;
using System.Windows.Forms;
using nsConfigDB;

namespace InventoryMSystem
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
            initialSystem();
            Application.Run(new frmMain());
        }

        static void initialSystem()
        {

            object oip = ConfigDB.getConfig("restIP");
            if (oip != null)
            {
                staticClass.restServerIP = (string)oip;
            }
            object oTcpPort = ConfigDB.getConfig("restPort");
            if (oTcpPort != null)
            {
                staticClass.restServerPort = (string)oTcpPort;
            }
            object oSerialPort = ConfigDB.getConfig("serialport");
            if (oSerialPort!=null)
            {
                staticClass.serialport_name = oSerialPort as string;
            }
        }
    }
}
