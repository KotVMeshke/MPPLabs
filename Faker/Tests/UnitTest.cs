using FakerLab.Classes;
using FakerLab.Entities;
using FakerLab.FakerLabClass;

namespace Tests
{
    public class UnitTest
    {

        [Fact]
        public void Test_WithoutInnerDTO()
        {
            var faker = new Faker("");
            var foo = faker.Create<Foo>();

            Assert.NotNull(foo!.List);

        }

        [Fact]
        public void Test_CycleDependency()
        {
            Faker faker = new Faker("");
            var res = faker.Create<A>();

            Assert.NotNull(res);
            Assert.NotNull(res.B);
            Assert.NotNull(res.B.C);
            Assert.Null(res.B.C.A);

        }

        [Fact]
        public void Test_WithPlugins()
        {
            Faker faker = new Faker();
            var res = faker.Create<Bar>();

            Assert.NotNull(res.String);
            Assert.NotNull(res.List);
        }

        [Fact]
        public void Test_WithInnerDTO()
        {
            Faker faker = new Faker();
            var res = faker.Create<BarWithInner>();

            Assert.NotNull(res.String);
            Assert.NotNull(res.List);
            Assert.NotNull(res.Foo);
            Assert.NotNull(res.Foo.List);
        }

        [Fact]
        public void Test_WithPrivateConstructor()
        {
            Faker faker = new Faker();
            var res = faker.Create<BarWithPrivate>();

            Assert.NotNull(res.String);
            Assert.Equal(res.String, "Str");
            Assert.NotNull(res.List);
         
        }

    }
}