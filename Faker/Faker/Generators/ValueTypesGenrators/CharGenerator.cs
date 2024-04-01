using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Generators.ValueTypesGenrators
{
    internal class CharGenerator : IGenerator<char>
    {
        private readonly Random _random = new Random();

        public char GenerateValue()
        {
            return (char)_random.Next(char.MaxValue);
        }
    }
}
