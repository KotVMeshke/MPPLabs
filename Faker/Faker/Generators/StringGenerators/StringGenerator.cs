using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Generators.StringGenerators
{
    internal class StringGenerator : IGenerator<string>
    {
        private readonly Random _random = new Random();
        public string GenerateValue()
        {
            string sourceString = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder resultString = new StringBuilder();
            int size = _random.Next(30) + 1;
            for (int i = 0; i < size; i++)
            {
                resultString.Append(sourceString[_random.Next(sourceString.Length)]);
            }

            return resultString.ToString();
        }
    }
}
