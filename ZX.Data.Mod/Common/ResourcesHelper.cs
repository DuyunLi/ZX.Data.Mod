using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZX.Data.Unity;
using System.Windows.Forms;
namespace ZX.Data.View.Common
{
    public class ResourcesHelper
    {
        public ResourcesFile resources { get; private set; }
        private LogHelper logHelper;
        private FileHelper fileHelper;
        public void Init()
        {
            var str = this.fileHelper.Reader(ResourcesFile.FileName);
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("load resources fail");
                logHelper.Error.Error("load resources fail");
                return;
            }
            try
            {
                resources = Newtonsoft.Json.JsonConvert.DeserializeObject<ResourcesFile>(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show("load resources fail");
                logHelper.Error.Error("load resources fail", ex);
            }
        }
        public ResourcesHelper(FileHelper fileHelper, LogHelper logHelper)
        {
            this.logHelper = logHelper;
            this.fileHelper = fileHelper;
            Init();
        }
        public string GetSystem(string key)
        {
            if (resources == null || resources.system == null)
            {
                return key;
            }
            if (resources.system.ContainsKey(key))
            {
                return resources.system[key];
            }
            else
            {
                return key;
            }
        }
        public string GetOhter(string key)
        {
            if (resources == null || resources.ohter == null)
            {
                return key;
            }
            if (resources.ohter.ContainsKey(key))
            {
                return resources.ohter[key];
            }
            else
            {
                return key;
            }
        }
    }
}
