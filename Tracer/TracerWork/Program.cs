using TracerSpace.Serializer;
using TracerSpace.Tracers;
using TracerSpace.Writer;
using TracerSpace.Writer.Interface;

namespace TracerWork
{
    internal class Program
    {
        static TestClass test = new TestClass();
        static XMLSerializer<TraceResult> XMLSerializer = new XMLSerializer<TraceResult>();
        static JSONSerializer<TraceResult> JSONSerializer = new JSONSerializer<TraceResult>();
        static IWriter writer;
        static void Main(string[] args)
        {
            test.M1();
            test.M6();

            test.RecursionMethod(5);
            Task.Run(() => test.M1());
            Task.Run(() => test.M2());
            Task.Run(() => test.M3());
            Task.Run(() => test.M4());
            writer = new ConsoleWriter();
            TraceResult result = TestClass.tracer.GetTraceResult();
            writer.Write(JSONSerializer.Serialize(result));
            writer.Write(XMLSerializer.Serialize(result));

            writer = new FileWriter();

            writer.Write(JSONSerializer.Serialize(result), "OutputJson.txt");
            writer.Write(XMLSerializer.Serialize(result), "OutputXml.txt");


        }
    }
}
