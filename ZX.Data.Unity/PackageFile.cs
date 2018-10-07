using System;
using System.IO;
namespace ZX.Data.Unity
{
    public class PackageFile
    {
        public static string FileName = "pak.json";
        /// <summary>
        /// mod列表
        /// </summary>
        public IEquatable<PackageItem> items { get; set; }
        public DateTime last_time { get; set; }
    }
    public class PackageItem
    {
        /// <summary>
        /// 文件路径
        /// </summary>
        public string file { get; set; }
        /// <summary>
        /// mod名字
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 是否激活mod
        /// </summary>
        public bool active { get; set; }
    }
}
