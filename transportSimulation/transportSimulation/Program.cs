using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace transportSimulation
{
    public class GlobleV
    {
        public static string Destnation = string.Empty;

        public static string CarID = "京A 12345";

        public static string GPS_Name = string.Empty;
        public static string Lat = string.Empty;
        public static string Lng = string.Empty;

        public static Form1 FirstForm = null;
        public static Form2 SecondForm = null;
        public static Form3 ThirdForm = null;
    }

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
            GlobleV.FirstForm = new Form1();
            Application.Run(GlobleV.FirstForm);
        }
    }
}
