using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ValueTypesGenrators
{
    internal class FloatGenerator : IGenerator<float>
    {
        private readonly Random _random = new Random();

        public float GetValue()
        {
            return _random.NextSingle();
        }
    }
}
