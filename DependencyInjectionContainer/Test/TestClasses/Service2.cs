using Core.Tests.Services;

namespace Test.Services;

public class Service2 : AbstractService2
{
    public override bool Method1()
    {
        return true;
    }

    public override int GetNumber()
    {
        return 0;
    }
}
