using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Generators.CollectionsGenerators
{
    internal class ListGenerator<T, K> : IGenerator<List<T>>
        where K : IGenerator<T>, new()
    {
        private readonly Random _random = new Random();

        public List<T> GenerateValue()
        {
            K generator = new K();
            int size = _random.Next(20) + 1;
            List<T> result = new List<T>(size);
            for (int i = 0; i < size; i++)
            {
                result.Add(generator.GenerateValue());
            }

            return result;
        }
    }
}
