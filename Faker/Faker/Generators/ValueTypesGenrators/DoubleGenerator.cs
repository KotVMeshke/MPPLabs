using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ValueTypesGenrators
{
    internal class DoubleGenerator : IGenerator<double>
    {
        private readonly Random _random = new Random();

        public double GetValue()
        {
            return _random.NextDouble();
        }
    }
}
