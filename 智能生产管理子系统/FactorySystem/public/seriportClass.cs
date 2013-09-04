using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RfidReader;
using System.IO.Ports;

using nsConfigDB;

namespace FactorySystem
{
    class seriportClass
    {
       
       
        public static IDataTransfer dataTransfer = new SerialPortDataTransfer();
        public static SerialPort comport = new SerialPort(ConfigDB.getConfig("name").ToString(), Convert.ToInt32(ConfigDB.getConfig("cmbBaudRate").ToString()), Parity.None, 8, StopBits.One);
     
        
    }
}
