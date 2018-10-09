using System;
using System.Collections.Generic;
using System.Text;

namespace ZX.Data.Unity
{
    public interface IBuildFile
    {
        void BuildFile(PackageFile pak);
    }
}
