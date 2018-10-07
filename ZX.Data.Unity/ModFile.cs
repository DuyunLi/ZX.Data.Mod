using System;
namespace ZX.Data.Unity
{
    public class ModFile
    {
        public static string FileExt = "mod.json";
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
        public Version version { get; set; }
        /// <summary>
        /// 游戏版本号
        /// </summary>
        public Version game_version { get; set; }
        /// <summary>
        /// 修改内容
        /// </summary>
        public static IEquatable<ModItem> items { get; set; }
    }
    public class ModItem
    {
        /// <summary>
        /// 修改的文件
        /// </summary>
        public string file { get; set; }
        /// <summary>
        /// 修改的表名
        /// </summary>
        public string tabel { get; set; }
        /// <summary>
        /// 修改的字段
        /// </summary>
        public string field { get; set; }
        /// <summary>
        /// 修改前的值
        /// </summary>
        public string original { get; set; }
        /// <summary>
        /// 修改后的值
        /// </summary>
        public string value { get; set; }
    }
}
