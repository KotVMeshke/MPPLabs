using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerSpace.Tracers.Interface;

namespace Test.ClassesForTests
{
    public class Bar
    {
        private ITracer _tracer;

        internal Bar(ITracer tracer)
        {
            _tracer = tracer;
        }

        public void InnerMethod()
        {
            _tracer.StartTrace();
            Thread.Sleep(20);
            Console.WriteLine("In InnerMethod() Bar class");
            _tracer.StopTrace();
        }
    }
}
