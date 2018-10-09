using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZX.Data.View.App_Start;
using Autofac;
using ZX.Data.View.Common;

namespace ZX.Data.View
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AutofacConfig.Register();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(
                new MainView(
                    AutofacConfig.container.Resolve<ResourcesHelper>(),
                    AutofacConfig.container.Resolve<PackageHelper>(),
                    AutofacConfig.container.Resolve<LogHelper>()
                    )
                );
        }
    }
}
