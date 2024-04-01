using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Generators.ValueTypesGenrators
{
    internal class ShortGenerator : IGenerator<short>
    {
        private readonly Random _random = new Random();

        public short GenerateValue()
        {
            return (short)_random.Next(short.MaxValue) ;
        }
    }
}
