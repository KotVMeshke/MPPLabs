using Core.Tests.Services;
using DependencyInjectionCore;
using Test.Services;

namespace Core.Tests;

[TestClass]
public class Tests
{
    DependencyProvider _provider;

    public Tests()
    {
        var config = new DependenciesConfiguration();
        config.Register<IService1, Service1>();
        config.Register<IService1, ExtraService1>();
        config.Register<AbstractService2, Service2>();
        config.Register<Service3, Service3>();

        _provider = new DependencyProvider(config);
    }

    [TestMethod]
    public void GetDependencyByInterface()
    {
        var service1 = _provider.Resolve<IService1>();
        
        Assert.IsNotNull(service1);
        Assert.IsTrue(service1.Method1());
    }

    [TestMethod]
    public void GetDependencyByAbstractClass()
    {
        var service2 = _provider.Resolve<AbstractService2>();

        Assert.IsNotNull(service2);
        Assert.IsTrue(service2.Method1());
    }

    [TestMethod]
    public void GetDependencyBySelf()
    {
        var service3 = _provider.Resolve<Service3>();

        Assert.IsNotNull(service3);
        Assert.IsTrue(service3.Method1());
    }

    [TestMethod]
    public void GetDependecyCollection()
    {
        var services = _provider.Resolve<IEnumerable<IService1>>();

        int actual = 0;
        foreach(var service in services)
            actual += service.GetNumber();

        int expected = 2;
        Assert.AreEqual(expected, actual);
    }
}
