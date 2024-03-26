﻿using TracerSpace.Tracers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TracerWork
{
    internal class TestClass
    {
        public static Tracer tracer = new Tracer();
        int count = 0;


        public void RecursionMethod(int n)
        {
            tracer.StartTrace();

            Thread.Sleep(50);
            if (n == 1)
                M1();

            if (n != 0)
                RecursionMethod(--n);

            tracer.StopTrace();
        }


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
            for (int i = 0; i < 10000;)
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
            for (int i = 0; i < 1000000;)
                i++;
            tracer.StopTrace();
        }

        public void M6()
        {
            tracer.StartTrace();
            Console.WriteLine("Hello6");
            for (int i = 0; i < 1000000;)
                i++;
            tracer.StopTrace();
        }
    }
}
