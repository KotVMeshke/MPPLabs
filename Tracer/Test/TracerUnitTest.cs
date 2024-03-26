using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.ClassesForTests;
using TracerSpace.Data;
using TracerSpace.Tracers;

namespace Test
{
    [TestClass]
    public class TracerUnitTest
    {
        public TraceResult? expectedResult;


        [TestMethod]
        public void TracerTest_With_Threads()
        {
            Tracer tracer = new Tracer();

            Foo foo = new(tracer);
            Bar bar = new(tracer);

            Thread thread1 = new(foo.MyMethod);
            Thread thread2 = new(bar.InnerMethod);

            thread1.Start();
            thread1.Join();

            thread2.Start();
            thread2.Join();

            TraceResult actualTraceResult = tracer.GetTraceResult();

            int thread1Id = thread1.ManagedThreadId;
            int thread2Id = thread2.ManagedThreadId;

            actualTraceResult._trace![0].Time.Should().BeInRange(130,150);
            actualTraceResult._trace![1].Time.Should().BeInRange(20,30);
        }
    }
}
