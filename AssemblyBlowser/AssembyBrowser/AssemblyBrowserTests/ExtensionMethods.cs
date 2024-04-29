using AssemblyBrowserTests.Names2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserTests.Names1
{
    public static class ExtensionMethods
    {
        public static void PrintInfo1(this string str)
        {
            //Console.WriteLine($"Info from MyClassA: {obj.Name}");
            Console.WriteLine(str);
        }

        public static void PrintInfo2(this List<int> list)
        {
            Console.WriteLine(string.Join(' ',list));
        }
    }
}
