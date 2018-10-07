using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZX.Data.View.App_Start
{
    public class AutofacConfig
    {

        public static void Register()
        {
            var builder = new ContainerBuilder();


            var container = builder.Build();
        }
    }
}
