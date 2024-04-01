using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Generators.ValueTypesGenrators
{
    internal class FloatGenerator : IGenerator<float>
    {
        private readonly Random _random = new Random();

        public float GenerateValue()
        {
            return _random.NextSingle();
        }
    }
}
