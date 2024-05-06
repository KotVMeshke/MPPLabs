using Core.Tests.Services;

namespace Test.Services;

public class RecursionService2 : AbstractService2
{
    IService1? service;

    public RecursionService2()
    { }

    public RecursionService2(IService1 service)
    {
        this.service = service;
    }

    public override bool Method1()
    {
        return true;
    }

    public override int GetNumber()
    {
        return service != null ? service.GetNumber() : int.MinValue;
    }
}
