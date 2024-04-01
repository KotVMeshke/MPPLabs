using FakerLab.Classes;
using FakerLab.FakerLabClass;

namespace FakerLab;

internal class Program
{
    static void Main(string[] args)
    {
        Faker faker = new Faker();
        Console.WriteLine(faker.Create<Foo>());
    }
}
