using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Generators.ValueTypesGenrators
{
    internal class DoubleGenerator : IGenerator<double>
    {
        private readonly Random _random = new Random();

        public double GenerateValue()
        {
            return _random.NextDouble();
        }
    }
}
