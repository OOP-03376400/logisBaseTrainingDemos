using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace FactorySystem
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
            initial_sys_config();
            Application.Run(new New_Mainfrm());
        }
        private static void initial_sys_config()
        {
            object o = nsConfigDB.ConfigDB.getConfig("serialport");
            if (o != null)
            {
                staticClass.serialport_name = (string)o;
            }
            o = nsConfigDB.ConfigDB.getConfig("restIP");
            if (o != null)
            {
                staticClass.restServerIP = (string)o;
            }
            o = nsConfigDB.ConfigDB.getConfig("restPort");
            if (o != null)
            {
                staticClass.restServerPort = (string)o;
            }
            o = nsConfigDB.ConfigDB.getConfig("zigbee_id");
            if (o != null)
            {
                staticClass.zigbee_id = o as string;
            }
        }
    }
}
