using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBWORK.WEB3
{
    public static  class Extension
    {
        public static string MakeDecimal(this string val)
        {
            var newVal = val + ".00";
            return newVal;
        }
    }
}
