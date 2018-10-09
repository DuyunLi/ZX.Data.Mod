using System;
using System.IO;
using System.Collections.Generic;
namespace ZX.Data.Unity
{
    public class PackageFile
    {
        public static string FileName = "./config/pak.json";
        /// <summary>
        /// mod列表
        /// </summary>
        public PackageItem[] items { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
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
        /// <summary>
        /// 版本号
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// mod类型
        /// </summary>
        public PackageType type { get; set; }
    }
    public enum PackageType
    {
        local,
        internet
    }
}
