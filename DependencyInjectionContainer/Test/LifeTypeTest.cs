using DependencyInjectionCore;
using Test.Services;

namespace Core.Tests;

[TestClass]
public class LifeTypeTest
{
    DependencyProvider _provider;

    public LifeTypeTest()
    {
        var config = new DependenciesConfiguration();
        config.RegisterIPD<Service3, Service3>();
        config.RegisterSingleton<SingletonService, SingletonService>();
        _provider = new DependencyProvider(config);
    }

    [TestMethod]
    public void CheckTransientMethodsForDifferentValues()
    {
        var service1 = _provider.Resolve<Service3>();
        var service2 = _provider.Resolve<Service3>();
        Assert.AreNotEqual(service1.GetNumber(), service2.GetNumber());
    }

    [TestMethod]
    public void CheckSingletonMethodsForDifferentValues()
    {
        var service1 = _provider.Resolve<SingletonService>();
        var service2 = _provider.Resolve<SingletonService>();
        Assert.AreEqual(service1.GetNumber(), service2.GetNumber());
    }
}
