using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerSpace.Tracers.Interface;

namespace Test.ClassesForTests
{
    public class Foo
    {
        private Bar _bar;
        private ITracer _tracer;

        internal Foo(ITracer tracer)
        {
            _tracer = tracer;
            _bar = new Bar(_tracer);
        }

        public void MyMethod()
        {
            _tracer.StartTrace();

            Console.WriteLine("In begin of InnerMethod() Foo class");
            
            _bar.InnerMethod();
            Thread.Sleep(100);

            Console.WriteLine("In the end of InnerMethod() Foo class");

            _tracer.StopTrace();
        }
    }
}
