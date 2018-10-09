using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ZX.Data.View.Common
{
    public class FileHelper
    {
        public string path { get; private set; }
        private LogHelper logHelper;
        public FileHelper(string path, LogHelper logHelper)
        {
            this.logHelper = logHelper;
            this.path = path;
        }
        public string Reader(string url)
        {
            logHelper.Debug.Debug("reader file :" + url);
            if (url.IndexOf(":") != 1)
            {
                url = Path.Combine(this.path, url);
            }
            using (var stream = new StreamReader(url))
            {
                return stream.ReadToEnd();
            }
        }
        public void Writer(string url,string txt)
        {
            logHelper.Debug.Debug("writer file :" + url);
            if (url.IndexOf(":") != 1)
            {
                url = Path.Combine(this.path, url);
            }
            using (var stream = new StreamWriter(url))
            {
                stream.Write(txt);
            }
        }
    }
}
