using DependencyInjectionCore;
using Test.Services;

namespace Core.Tests;

[TestClass]
public class GenericsTest
{
    DependencyProvider _provider;

    public GenericsTest()
    {
        var config = new DependenciesConfiguration();
        config.Register<IInside, SomeRepository>();
        config.Register(typeof(IService<>), typeof(ServiceImpl<>));
        _provider = new DependencyProvider(config);
    }

    [TestMethod]
    public void SmokeTestOfTemplateClasses()
    {
        var service = _provider.Resolve<IService<IInside>>();
        int actual = service.GetNumber();
        int expected = 2;
        Assert.AreEqual(expected, actual);
    }

    
    
}
