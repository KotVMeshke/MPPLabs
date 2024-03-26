using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TracerSpace.Data;
using TracerSpace.Serializer;
using TracerSpace.Tracers;

namespace Test
{
    [TestClass]
    public class SerializerUnitTest
    {
        public JSONSerializer<TraceResult> serializerJSON = new JSONSerializer<TraceResult> ();
        public XMLSerializer<TraceResult> serializerXML = new XMLSerializer<TraceResult>();
        public TraceResult result;

        [TestInitialize]
        public void TestInitialize()
        {
            MethodData MethodData1 = new("method", 10, "Test1", []);

            MethodData MethodData2 = new("method", 20, "Test2", []);

            MethodData MethodData3 = new("method", 30, "Test1", []);

            MethodData MethodData4 = new("name", 40, "className", [MethodData1, MethodData2]);

            MethodData MethodData5 = new("method", 50, "Some", []);

            MethodData MethodData6 = new("name", 60, "className", [MethodData5]);

            MethodData MethodData7 = new("name", 70, "className", [MethodData6]);

            List<MethodData> MethodDatas =
            [
                MethodData3,
                MethodData4,
                MethodData7
            ];

            ThreadData thread = new ThreadData(MethodDatas);
            result = new TraceResult([thread]);
        }

        [TestMethod]
        public void JSONSerializer_Test()
        {
            var actualJson = serializerJSON.Serialize(result);
            using var file = new StreamReader("JSONTest.txt");
            string expectedJson = file.ReadToEnd();
            actualJson.Should().Be(expectedJson);

        }

        [TestMethod]
        public void XMLSerializer_Test()
        {
            var actualXml = serializerXML.Serialize(result);
            using var file = new StreamReader("XMLTest.txt");
            string expectedXml = file.ReadToEnd();
            actualXml.Should().Be(expectedXml);

        }
    }
}
