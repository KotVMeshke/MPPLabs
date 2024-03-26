using FluentAssertions;
using System.Diagnostics;
using Tests.ClassesForTests;
using TracerSpace.Data;
using TracerSpace.Serializer;
using TracerSpace.Tracers;

namespace Test
{
    [TestClass]
    public class ThreadUnitTest
    {
        [TestMethod]
        public void ThreadTime_WithNoMethods_Test()
        {
            ThreadData thread = new ThreadData();
            thread.Time.Should().Be(0);
        }

        [TestMethod]
        public void ThreadTime_Test()
        {
            MethodData MethodData1 = new(
                    "method",
                    10,
                    "Test1",
                    []
                 );

            MethodData MethodData2 = new(
                "method",
                20,
                "Test2",
                []
            );

            MethodData MethodData3 = new(
                "method",
                30,
                "Test1",
                []
            );

            MethodData MethodData4 = new(
                "name",
                40,
                "className",
                [MethodData1, MethodData2]
                );

            MethodData MethodData5 = new(
                "method",
                50,
                "Some",
                []
            );

            MethodData MethodData6 = new(
                "name",
                60,
                "className",
                [MethodData5]
                );

            MethodData MethodData7 = new(
                "name",
                70,
                "className",
                [MethodData6]
                );

            List<MethodData> MethodDatas =
            [
                MethodData3,
                MethodData4,
                MethodData7
            ];

            ThreadData thread = new ThreadData(MethodDatas);

            thread.Time.Should().Be(140);
        }

    }
}