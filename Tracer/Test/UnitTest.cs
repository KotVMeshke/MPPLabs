using System.Diagnostics;
using Tests.ClassesForTests;
using TracerSpace.Serializer;
using TracerSpace.Tracers;

namespace Test
{
    [TestClass]
    public class UnitTest
    {
        private Tracer? _trace;
        private JSONSerializer<TraceResult> _serializerJSON = new JSONSerializer<TraceResult>();
        private XMLSerializer<TraceResult> _serializerXML = new XMLSerializer<TraceResult>();
        private TestClass1 _testClass1 = new TestClass1();
        
        [TestInitialize]
        public void TestInitialize()
        {
            _trace = new Tracer();
        }

        [TestMethod]
        public void TracerTest_Without_Threads()
        {
            _testClass1.M1();
            _testClass1.M6();
            var result = _trace.GetTraceResult();
            Assert.IsNotNull(result);
            //using var file = new StreamReader("JsonTest1.txt");
            //var str = file.ReadToEnd();
            //Assert.AreEqual(_serializerJSON.Serialize(result), str);
        }

    }
}