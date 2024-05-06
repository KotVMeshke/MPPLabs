using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserLib.AssemblyBrowser
{
    public static class Test
    {

        public static void method(this string str, int f)
        {
            Console.WriteLine(str);
        }
    }
}
