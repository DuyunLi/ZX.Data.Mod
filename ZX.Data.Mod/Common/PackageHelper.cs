﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZX.Data.Unity;

namespace ZX.Data.View.Common
{
    public class PackageHelper
    {
        public PackageFile packageFile { get; private set; }
        private LogHelper logHelper;
        private FileHelper fileHelper;
        private IBuildFile buildFile;
        public void Init()
        {
            var str = this.fileHelper.Reader(PackageFile.FileName);
            if (string.IsNullOrEmpty(str))
            {
                MessageBox.Show("load packge fail");
                logHelper.Error.Error("load packge fail");
                return;
            }
            try
            {
                packageFile = Newtonsoft.Json.JsonConvert.DeserializeObject<PackageFile>(str);
            }
            catch (Exception ex)
            {
                MessageBox.Show("load packge fail");
                logHelper.Error.Error("load packge fail", ex);
            }
        }
        public PackageHelper(FileHelper fileHelper, LogHelper logHelper)
        {
            this.logHelper = logHelper;
            this.fileHelper = fileHelper;
            Init();
        }
        public void Save()
        {
            try
            {
                fileHelper.Writer(PackageFile.FileName, Newtonsoft.Json.JsonConvert.SerializeObject(packageFile));
            }
            catch (Exception ex)
            {
                MessageBox.Show("save packge fail");
                logHelper.Error.Error("save packge fail", ex);
            }
        }
        public void Build()
        {
            if (buildFile != null)
            {
                buildFile.BuildFile(this.packageFile);
            }
        }
        public void UpdateMod(IEnumerable< PackageItem> package)
        {

        }
    }
}
