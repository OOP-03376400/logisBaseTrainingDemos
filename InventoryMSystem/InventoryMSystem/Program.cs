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
            Application.Run(new Form1());
        }

        static void initialSystem()
        {

            object oip = ConfigDB.getConfig("ip");
            if (oip != null)
            {
                staticClass.ip = (string)oip;
            }
            object oTcpPort = ConfigDB.getConfig("tcp_port");
            if (oTcpPort != null)
            {
                staticClass.tcp_port = int.Parse((string)oTcpPort);
            }
        }
    }
}
