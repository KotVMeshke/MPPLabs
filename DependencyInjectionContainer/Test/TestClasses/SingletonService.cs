namespace Test.Services;

public class SingletonService
{
    private int number = new Random().Next();
    public bool Method1()
    {
        return true;
    }

    public int GetNumber()
    {
        return number;
    }
}
