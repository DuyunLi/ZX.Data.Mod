using System;
using System.Collections.Generic;
using System.Text;

namespace ZX.Data.Unity
{
    public class ResourcesFile
    {
        public static string FileName = "./config/resource.json";
        public Version version { get; set; }
        public Dictionary<string,string> system { get; set; }
        public Dictionary<string, string> ohter { get; set; }
        public IEnumerable<TableHeaderResourcesItem> table { get; set; }
    }
    public class TableHeaderResourcesItem
    {
    }
}
