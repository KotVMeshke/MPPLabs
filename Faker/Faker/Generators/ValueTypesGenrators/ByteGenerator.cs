using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ValueTypesGenrators
{
    internal class ByteGenerator : IGenerator<byte>
    {
        private readonly Random _random = new Random();

        public byte GetValue()
        {
            return (byte) _random.Next(byte.MaxValue);
        }
    }
}
