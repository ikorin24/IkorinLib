using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkorinLib
{
    internal static class ThrowException
    {
        public static void IfNullArg(object obj, string argName = null)
        {
            if(obj == null) { throw new ArgumentNullException(argName ?? ""); }
        }
    }
}
