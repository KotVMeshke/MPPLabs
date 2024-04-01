using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Generators.ValueTypesGenrators
{
    internal class ByteGenerator : IGenerator<byte>
    {
        private readonly Random _random = new Random();

        public byte GenerateValue()
        {
            return (byte) _random.Next(byte.MaxValue);
        }
    }
}
