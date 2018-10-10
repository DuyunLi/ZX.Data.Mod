using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZX.Data.View.Common;

namespace ZX.Data.View
{
    public partial class about : Form
    {
        private ResourcesHelper resourcesHelper;
        public about(ResourcesHelper resourcesHelper)
        {
            this.resourcesHelper = resourcesHelper;
            InitializeComponent();
        }

        private void about_Load(object sender, EventArgs e)
        {
            label1.Text = @"这是一个开源项目\n
项目地址:https://github.com/DuyunLi/ZX.Data.Mod \n
当前程序版本:"+ resourcesHelper.GetSystem("about.version")
            + "\n特别感谢zhyzcl贡献在git的zx工具代码促成了这个项目";
            label2.Text = resourcesHelper.GetSystem("about.desc");
        }
    }
}
