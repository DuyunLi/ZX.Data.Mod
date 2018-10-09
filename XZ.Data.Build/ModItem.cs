using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XZ.Data.Build
{
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
