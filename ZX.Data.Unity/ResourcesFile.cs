using System;
using System.Collections.Generic;
using System.Text;

namespace ZX.Data.Unity
{
    public class ResourcesFile
    {
        public static string FileExt = "resource.json";
        public Version version { get; set; }
        public IEnumerable<SystemResourcesItem> system { get; set; }
        public IEnumerable<OhterResourcesItem> ohter { get; set; }
        public IEnumerable<TableHeaderResourcesItem> table { get; set; }
    }
    public class SystemResourcesItem
    {
        public string key { get; set; }
        public string value { get; set; }
    }
    public class TableHeaderResourcesItem
    {
    }
    public class OhterResourcesItem
    {
        public string key { get; set; }
        public string value { get; set; }
    }
}
