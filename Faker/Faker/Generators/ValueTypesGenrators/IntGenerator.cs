using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ValueTypesGenrators
{
    internal class IntGenerator : IGenerator<int>
    {
        private readonly Random _random = new Random();
        public int GetValue()
        {
            return _random.Next();
        }
    }
}
