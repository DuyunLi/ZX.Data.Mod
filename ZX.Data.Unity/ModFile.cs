using System;
using System.Collections.Generic;
namespace ZX.Data.Unity
{
    public class ModFile
    {
        public static string FileName = "mod.json";
        /// <summary>
        /// mod名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// mod 说明
        /// </summary>
        public string desc { get; set; }
        /// <summary>
        /// 游戏版本号
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// 游戏版本号
        /// </summary>
        public string game_version { get; set; }
        /// <summary>
        /// 文件列表
        /// </summary>
        public static IEnumerator<string> files { get; set; }
        /// <summary>
        /// 图片列表
        /// </summary>
        public static IEnumerator<string> images { get; set; }
    }
}
