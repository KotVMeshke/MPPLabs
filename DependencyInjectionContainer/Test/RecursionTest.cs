using Core.Tests.Services;
using DependencyInjectionCore;
using Test.Services;

namespace Core.Tests;

[TestClass]
public class RecursionTest
{
    DependencyProvider _provider;

    public RecursionTest()
    {
        var config = new DependenciesConfiguration();
        config.Register<IService1, Service1>();
        config.Register<AbstractService2, RecursionService2>();
        config.Register<RecursionService3, RecursionService3>();
        _provider = new DependencyProvider(config);
    }

    [TestMethod]
    public void SimpleServiceRecursion()
    {
        var service = _provider.Resolve<AbstractService2>();
        int expected = 1;
        int actual = service.GetNumber();
        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    public void ThreeLvlServiceRecursion()
    {
        var service = _provider.Resolve<RecursionService3>();
        int expected = 2;
        int actual = service.GetNumber();
        Assert.AreEqual(expected, actual);
    }
    
}
