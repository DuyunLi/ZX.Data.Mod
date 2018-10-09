using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZX.Data.Unity;
using ZX.Data.View.Common;

namespace ZX.Data.View
{
    public partial class MainView : Form
    {
        private ResourcesHelper resourcesHelper;
        private PackageHelper packageHelper;
        private LogHelper logHelper;
        private bool saveFlag;
        public MainView(ResourcesHelper resourcesHelper, PackageHelper packageHelper, LogHelper logHelper)
        {
            InitializeComponent();
            this.packageHelper = packageHelper;
            this.Text = resourcesHelper.GetSystem("main.name");
            this.fileToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open");
            this.refreshToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.refresh");
            this.aboutToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.about");
            this.openFileToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.file");
            this.openFolderToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.folder");
            this.searchToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.internet");
            this.openFileToolStripMenuItem1.Text = resourcesHelper.GetSystem("main.menu.open.file");
            this.openFlolerToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.folder");
            this.searchInternetToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.open.internet");
            this.upItemToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.up");
            this.downItemToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.down");
            this.updateItemToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.update");
            this.refreshListToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.refreshList");
            this.allToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.all");
            this.activeToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.active");
            this.inactiveToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.inactive");
            this.allToolStripMenuItem1.Text = resourcesHelper.GetSystem("main.menu.all");
            this.localToolStripMenuItem.Text = resourcesHelper.GetSystem("main.view.active.local");
            this.internetToolStripMenuItem.Text = resourcesHelper.GetSystem("main.view.active.internet");
            this.filterToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.filter");
            this.buildToolStripMenuItem.Text = resourcesHelper.GetSystem("main.menu.build");
            this.buildToolStripMenuItem1.Text = resourcesHelper.GetSystem("main.menu.build");
            this.resourcesHelper = resourcesHelper;
            this.logHelper = logHelper;
            RefreshPackage();
        }
        public void RefreshPackage()
        {
            saveFlag = true;
            if (packageHelper.packageFile == null)
            {
                MessageBox.Show("load package fail!");
                saveFlag = false;
                return;
            }
            if (packageHelper.packageFile.items == null)
            {
                saveFlag = false;
                return;
            }
            view.Items.Clear();
            IEnumerable<PackageItem> items = packageHelper.packageFile.items;
            if (!allToolStripMenuItem.Checked)
            {
                if (activeToolStripMenuItem.Checked)
                {
                    items = items.Where(s => s.active);
                }else
                {

                    items = items.Where(s => !s.active);
                }
            }
            if (!allToolStripMenuItem1.Checked)
            {
                if (localToolStripMenuItem.Checked)
                {
                    items = items.Where(s => s.type == PackageType.local);
                }
                else
                {

                    items = items.Where(s => s.type != PackageType.local);
                }
            }
            foreach (var item in items)
            {
                var li = new ListViewItem(item.name);
                li.SubItems.Add(item.version?.ToString());
                var sub = li.SubItems.Add(resourcesHelper.GetSystem($"main.view.active.{item.type}"));
                sub.Tag = item.type;
                li.Checked = item.active;
                li.ForeColor = li.Checked ? Color.Black : Color.FromArgb(0, 88, 88, 88);
                view.Items.Add(li);
            }
            saveFlag = false;
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            saveFlag = true;
            view.View = System.Windows.Forms.View.Details;
            view.CheckBoxes = true;
            view.FullRowSelect = true;
            view.MultiSelect = false;
            view.Columns.Add(resourcesHelper.GetSystem("main.column.name"), this.Size.Width - 220, HorizontalAlignment.Center);
            view.Columns.Add(resourcesHelper.GetSystem("main.column.version"), 80, HorizontalAlignment.Center);
            view.Columns.Add(resourcesHelper.GetSystem("main.column.type"), 80, HorizontalAlignment.Center);
            RefreshPackage();
        }

        private void openFile()
        {

        }
        private void openFolder()
        {

        }
        private void searchInternet()
        {

        }
        private void about()
        {

        }
        private void build()
        {
            if (packageHelper.packageFile == null || packageHelper.packageFile.items == null)
            {
                return;
            }
            if (MessageBox.Show(resourcesHelper.GetSystem("main.msg.build"), resourcesHelper.GetSystem("main.title.build"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                packageHelper.Build();
            }
        }
        private void refreshClick()
        {
            if (packageHelper.packageFile == null || packageHelper.packageFile.items == null)
            {
                return;
            }
            if (MessageBox.Show(resourcesHelper.GetSystem("main.msg.refresh"), resourcesHelper.GetSystem("main.title.refresh"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                packageHelper.UpdateMod(packageHelper.packageFile.items);
            }
            RefreshPackage();

        }
        private void view_ItemChecked(object sender, ItemCheckEventArgs e)
        {
            if (!saveFlag)
            {
                if (packageHelper.packageFile == null || packageHelper.packageFile.items == null)
                {
                    return;
                }
                var li = view.Items[e.Index];
                if (li == null)
                {
                    return;
                }
                var name = li.Text;
                li.ForeColor = (e.NewValue == CheckState.Checked) ? Color.Black : Color.FromArgb(0, 88, 88, 88);
                var pak = packageHelper.packageFile.items.Where(s => s.name == name).FirstOrDefault();
                if (pak != null)
                {
                    pak.active = e.NewValue == CheckState.Checked;
                    packageHelper.Save();
                }
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if(view.SelectedItems.Count != 0)
            {
                var li = view.SelectedItems[0];
                upItemToolStripMenuItem.Enabled = true;
                downItemToolStripMenuItem.Enabled = true;
                if (li.Index == 0)
                {
                    upItemToolStripMenuItem.Enabled = false;
                }else if(li.Index == view.Items.Count - 1)
                {
                    downItemToolStripMenuItem.Enabled = false;
                }
                
                var type = li.SubItems.Count > 2 ? li.SubItems[2]?.Tag : null;
                if (type != null)
                {
                    updateItemToolStripMenuItem.Enabled = (PackageType)type != PackageType.local;
                }
            }
            else
            {
                upItemToolStripMenuItem.Enabled = false;
                downItemToolStripMenuItem.Enabled = false;
                updateItemToolStripMenuItem.Enabled = false;
            }
        }

        private void upItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (view.SelectedItems.Count != 0)
            {
                if (packageHelper.packageFile == null || packageHelper.packageFile.items == null)
                {
                    return;
                }
                try
                {
                    this.saveFlag = true;
                    var li = view.SelectedItems[0];
                    var index = li.Index;
                    if (index == 0)
                    {
                        return;
                    }
                    var item = packageHelper.packageFile.items[index];
                    packageHelper.packageFile.items[index] = packageHelper.packageFile.items[index - 1];
                    packageHelper.packageFile.items[index - 1] = item;
                    view.Items.RemoveAt(index);
                    view.Items.Insert(index-1, li);
                    packageHelper.Save();
                }
                finally
                {

                    this.saveFlag = false;
                }
            }
        }

        private void downItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (view.SelectedItems.Count != 0)
            {
                if (packageHelper.packageFile == null || packageHelper.packageFile.items == null)
                {
                    return;
                }
                try
                {
                    this.saveFlag = true;
                    var li = view.SelectedItems[0];
                    var index = li.Index;
                    if (index == view.Items.Count - 1)
                    {
                        return;
                    }
                    var item = packageHelper.packageFile.items[index];
                    packageHelper.packageFile.items[index] = packageHelper.packageFile.items[index + 1];
                    packageHelper.packageFile.items[index + 1] = item;
                    view.Items.RemoveAt(index);
                    view.Items.Insert(index + 1, li);
                    packageHelper.Save();
                }
                finally
                {

                    this.saveFlag = false;
                }
            }
        }

        private void updateItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (view.SelectedItems.Count != 0)
            {
                if (packageHelper.packageFile == null || packageHelper.packageFile.items == null)
                {
                    return;
                }
                try
                {
                    this.saveFlag = true;
                    var li = view.SelectedItems[0];
                    var name = li.Text;
                    var pak = packageHelper.packageFile.items.Where(s => s.name == name).FirstOrDefault();
                    if (pak != null)
                    {
                        packageHelper.UpdateMod(new PackageItem[] { pak });
                    }
                }
                finally
                {

                    this.saveFlag = false;
                }
            }
        }

        private void refreshListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshClick();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeToolStripMenuItem.Checked = false;
            inactiveToolStripMenuItem.Checked = false;
            allToolStripMenuItem.Checked = true;
            RefreshPackage();
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeToolStripMenuItem.Checked = true;
            inactiveToolStripMenuItem.Checked = false;
            allToolStripMenuItem.Checked = false;
            RefreshPackage();
        }

        private void inactiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeToolStripMenuItem.Checked = false;
            inactiveToolStripMenuItem.Checked = true;
            allToolStripMenuItem.Checked = false;
            RefreshPackage();
        }

        private void allToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            localToolStripMenuItem.Checked = false;
            internetToolStripMenuItem.Checked = false;
            allToolStripMenuItem1.Checked = true;
            RefreshPackage();
        }

        private void localToolStripMenuItem_Click(object sender, EventArgs e)
        {

            localToolStripMenuItem.Checked = true;
            internetToolStripMenuItem.Checked = false;
            allToolStripMenuItem1.Checked = false;
            RefreshPackage();
        }

        private void internetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            localToolStripMenuItem.Checked = false;
            internetToolStripMenuItem.Checked = true;
            allToolStripMenuItem1.Checked = false;
            RefreshPackage();
        }

        private void openFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFlolerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFolder();
        }

        private void searchInternetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchInternet();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshClick();
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFolder();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            searchInternet();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about();
        }

        private void buildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            build();
        }

        private void buildToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            build();
        }
    }
}
