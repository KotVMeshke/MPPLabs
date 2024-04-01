using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.ValueTypesGenrators
{
    internal class DecimalGenerator : IGenerator<decimal>
    {
        private readonly Random _random = new Random();

        public decimal GetValue()
        {
            int lo = _random.Next();
            int mid = _random.Next();
            int hi = _random.Next();
            bool isNegative = _random.Next(1) == 1;
            byte scale = (byte)_random.Next(29);

            return new decimal(lo,mid,hi,isNegative,scale);
        }
    }
}
