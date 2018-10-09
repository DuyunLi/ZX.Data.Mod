using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZX.Data.View.Common;
using System.IO;
using ZX.Data.Unity;

namespace ZX.Data.View.App_Start
{
    public class AutofacConfig
    {
        public static IContainer container { get; private set; }
        public static void Register()
        {
            log4net.ILog loginfo = log4net.LogManager.GetLogger("loginfo");
            log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");
            var path = System.AppDomain.CurrentDomain.BaseDirectory;
            var builder = new ContainerBuilder();
            var log = new LogHelper(loginfo, logerror, loginfo);
            builder.RegisterInstance(log).SingleInstance();

            var file = new FileHelper(path,log);
            builder.RegisterInstance(file).SingleInstance();

            builder.RegisterInstance(new PackageHelper(file, log)).SingleInstance();
            builder.RegisterInstance(new ResourcesHelper(file, log)).SingleInstance();

            container = builder.Build();
        }
    }
}
