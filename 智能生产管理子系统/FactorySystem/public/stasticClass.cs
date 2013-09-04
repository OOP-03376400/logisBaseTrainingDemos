using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace FactorySystem
{
    public class staticClass
    {
        public static Thread thread = null;
        public static UdpClient server = null;
        public static IPEndPoint iep = null;

        public static string restServerIP = "localhost";
        public static string restServerPort = "9002";
        public static int interval = 15000;
        public static string serialport_name = string.Empty;
        public static string zigbee_id = string.Empty;
    }
}
