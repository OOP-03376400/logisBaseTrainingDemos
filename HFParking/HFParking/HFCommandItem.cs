using System;
using System.Collections.Generic;
using System.Text;

namespace LogisTechBase
{
    public class HFCommandItem
    {
        public static string 查询读写器状态 = "0108000304FF0000";
        public static string 设置15693协议 = "010C00030410002101000000";
        public static string 设置14443A协议 = "010c00030410002101090000";
        public static string 设置14443B协议 = "010C000304100021010C0000";
        public static string 设置TAGIT协议 = "010C00030410002101130000";
        public static string 读取15693协议标签 = "010B000304142401000000";
        public static string 读取14443A协议标签 = "0109000304A0010000";
        public static string 读取14443B协议标签 = "0109000304B0040000";
        public static string 读取TAGIT协议标签 = "010B000304340050000000";
        Dictionary<string, string> _ItemDic = new Dictionary<string, string>();
        List<string> _keyWordsList = new List<string>();

      
      
    }
}
