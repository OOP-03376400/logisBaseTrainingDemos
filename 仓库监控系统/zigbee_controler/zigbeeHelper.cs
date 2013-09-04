using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

namespace zigbee_controler
{
    public delegate void delZigbeeCallback(int index, string nodeID, int humi, int temp);
    public class ZigbeeHelper
    {
        string data_to_dispose = string.Empty;
        public event delZigbeeCallback eventZigInfo;
        string BytesToHexStringWithNospace(byte[] value)
        {
            string str = "";
            for (int i = 0; i < value.Length; i++)
            {
                str += value[i].ToString("X2");
            }
            return str;
        }
        string BytesToHexString(byte[] value)
        {
            string str = "";
            for (int i = 0; i < value.Length; i++)
            {
                str += " ";
                str += value[i].ToString("X2");
            }
            return str;
        }
        /// <summary>
        /// 接收数据源（串口）数据
        /// </summary>
        /// <param name="value"></param>
        public void Parse(byte[] value)
        {
            try
            {
                this.data_to_dispose += BytesToHexStringWithNospace(value);
                MatchCollection mc = Regex.Matches(data_to_dispose, @"[0-9a-fA-F]{44}FFFF");
                //依次添加到列表中
                foreach (Match m in mc)
                {
                    string strCmd = m.ToString();
                    string strID = strCmd.Substring(0, 4);
                    int id = Int32.Parse(strID, NumberStyles.AllowHexSpecifier);
                    //使用节点的地址作为唯一标识
                    string strNodeID = strCmd.Substring(4, 16);
                    string strHumidity = strCmd.Substring(24, 4);
                    int Humidity = Int32.Parse(strHumidity, NumberStyles.AllowHexSpecifier);
                    string strTemp = strCmd.Substring(28, 4);
                    int temperature = Int32.Parse(strTemp, NumberStyles.AllowHexSpecifier);
                    Debug.WriteLine(string.Format("zigbeeHelper Parse -> id = {0},nodeID = {1} Humidity = {2} temperature = {3} ",
                                    id.ToString(), strNodeID, Humidity.ToString(), temperature.ToString()));
                    if (this.eventZigInfo != null)
                    {
                        this.eventZigInfo(id, strNodeID, Humidity, temperature);
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(string.Format("zigbeeHelper Parse Exception -> {0}", ex.Message));
            }

        }
    }
}
