using Core.Tests.Services;

namespace Test.Services;

public class ExtraService1 : IService1
{
    public bool Method1()
    {
        return true;
    }

    public int GetNumber() => 1;
}
