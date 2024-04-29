using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyBrowserTests.Names2
{
    public class MyClassC
    {
        private int _value;

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public void DoSomething()
        {
            Console.WriteLine("MyClassC: Doing something...");
        }
    }
}

