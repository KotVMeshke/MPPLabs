namespace Test.Services;

public class Service3
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
