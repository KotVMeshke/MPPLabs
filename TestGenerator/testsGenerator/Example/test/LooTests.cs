using Moq;
using LooNamespace;

namespace LooNamespace.Tests;
[TestClass]
public class Loo_Tests
{
    private Loo Loo;
    private Mock<ILoo> _loo;
    [TestInitialize]
    public void Initialize()
    {
        _loo = new Mock<ILoo>();
        Loo = new Loo(_loo.Object);
    }

    [TestMethod]
    public void Olo()
    {
        int a = 0;
        float b = 0;
        bool c = false;
        float actual = Loo.Olo(a, b, c);
        float expected = 0;
        Assert.Equal(actual, expected);
        Assert.Fail(autogenerated);
    }
}