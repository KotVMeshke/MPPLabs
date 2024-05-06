namespace Test.Services;

public interface IInside
{
    public int GetNumber();
}

public class SomeRepository : IInside
{
    public int GetNumber()
    {
        return 1;
    }
}

interface IService<TInside>
    where TInside : IInside
{
    public int GetNumber();
}

class ServiceImpl<IInside> : IService<IInside>
    where IInside : Services.IInside
{
    Services.IInside? inside;

    public ServiceImpl() { }

    public ServiceImpl(IInside insideImpl)
    {
        this.inside = insideImpl;
    }

    public int GetNumber()
    {
        if (inside != null)
            return 1 + inside.GetNumber();
        return 0;
    }
}
