using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ValueTypesGenrators
{
    internal class CharGenerator : IGenerator<char>
    {
        private readonly Random _random = new Random();

        public char GetValue()
        {
            return (char)_random.Next(char.MaxValue);
        }
    }
}
