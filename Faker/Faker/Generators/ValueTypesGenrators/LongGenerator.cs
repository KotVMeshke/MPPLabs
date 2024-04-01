using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ValueTypesGenrators
{
    internal class LongGenerator : IGenerator<long>
    {
        private readonly Random _random = new Random();

        public long GetValue()
        {
            return _random.NextInt64();
        }
    }
}
