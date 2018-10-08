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
    public partial class MainView : Form
    {
        private ResourcesHelper resourcesHelper;
        private LogHelper logHelper;
        public MainView(ResourcesHelper resourcesHelper,LogHelper logHelper)
        {
            InitializeComponent();
            this.Text = resourcesHelper.GetSystem("main.name");
            this.fileToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open");
            this.refreshToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.refresh");
            this.aboutToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.about");
            this.openFileToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.file");
            this.openFolderToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.folder");
            this.searchToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.internet");
            this.resourcesHelper = resourcesHelper;
            this.logHelper = logHelper;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            view.View = System.Windows.Forms.View.Details;
            view.Columns.Add(resourcesHelper.GetSystem("main.column.name"), this.Size.Width - 250, HorizontalAlignment.Center);
            view.Columns.Add(resourcesHelper.GetSystem("main.column.version"), 80, HorizontalAlignment.Center);
            view.Columns.Add(resourcesHelper.GetSystem("main.column.type"), 80, HorizontalAlignment.Center);
            view.Columns.Add(resourcesHelper.GetSystem("main.column.active"), 80, HorizontalAlignment.Center);
        }
    }
}
