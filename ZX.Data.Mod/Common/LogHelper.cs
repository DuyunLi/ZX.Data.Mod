using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZX.Data.View.Common
{
    public class LogHelper
    {
        private log4net.ILog loginfo;
        private log4net.ILog logerror;
        private log4net.ILog logdebug;
        public LogHelper(log4net.ILog loginfo, log4net.ILog logerror, log4net.ILog logdebug)
        {
            this.loginfo = loginfo;
            this.logerror = logerror;
            this.logdebug = logdebug;
        }
        public log4net.ILog Info
        {
            get { return loginfo; }
        }
        public log4net.ILog Error
        {
            get { return logerror; }
        }
        public log4net.ILog Debug
        {
            get { return logdebug; }
        }
    }
}
