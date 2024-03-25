using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPP_LABA1_Console.Tracers;

namespace Tests.ClassesForTests
{
    internal class TestClass1
    {

        public static Tracer tracer = new Tracer();
        public void M1()
        {
            tracer.StartTrace();
            M2();
            M4();

            tracer.StopTrace();

        }
        public void M2()
        {
            tracer.StartTrace();
            M3();
            tracer.StopTrace();
        }
        public void M3()
        {
            tracer.StartTrace();
            for (int i = 0; i < 100000;)
                i++;

            tracer.StopTrace();
        }
        public void M4()
        {
            tracer.StartTrace();

            M5();
            tracer.StopTrace();
        }
        public void M5()
        {
            tracer.StartTrace();
            Console.WriteLine("Hello5");
            for (int i = 0; i < 10000000;)
                i++;
            tracer.StopTrace();
        }

        public void M6()
        {
            tracer.StartTrace();
            Console.WriteLine("Hello6");
            for (int i = 0; i < 10000000;)
                i++;
            tracer.StopTrace();
        }


    }
}
