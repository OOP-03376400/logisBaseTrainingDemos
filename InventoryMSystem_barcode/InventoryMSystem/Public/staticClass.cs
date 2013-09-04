using System;
using System.Collections.Generic;
using System.Text;
using Db4objects.Db4o;

namespace InventoryMSystem
{
    public static class staticClass
    {
        public static DateTime timeBase = DateTime.Now;
        //public static string configFilePath = "app.config";
        public static string PicturePath = @"商品图片\";
        //public static DBType currentDbType = DBType.None;
        public static string currentDBConnectString = string.Empty;
        //public static IObjectContainer db = Db4oFactory.OpenFile(configFilePath);

        public static string restServerIP = "localhost";
        public static string restServerPort = "9002";
        public static string serialport_name = string.Empty;
    }

}
