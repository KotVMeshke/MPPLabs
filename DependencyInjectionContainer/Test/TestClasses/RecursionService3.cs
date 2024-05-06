using Core.Tests.Services;

namespace Test.Services;

public class RecursionService3
{
    AbstractService2? service;

    public RecursionService3()
    { }

    public RecursionService3(AbstractService2 service)
    {
        this.service = service;
    }

    public bool Method1()
    {
        return true;
    }

    public int GetNumber()
    {
        if (service != null)
            return 1 + service.GetNumber();
        else
            return int.MinValue;
    }
}
