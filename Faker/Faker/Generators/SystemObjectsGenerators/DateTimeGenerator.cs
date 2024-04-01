using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faker.Generators.SystemObjectsGenerators
{
    internal class DateTimeGenerator : IGenerator<DateTime>
    {
        private readonly Random _random = new Random();

        public DateTime GetValue()
        {
            int year = _random.Next(20000) + 1;
            int month = _random.Next(12) + 1;
            int day = _random.Next(28) + 1;
            int hour = _random.Next(24) + 1;
            int minute = _random.Next(60) + 1;
            int second = _random.Next(60) + 1;

            return new DateTime(year, month, day, hour, minute, second, CultureInfo.CurrentCulture.Calendar);
        }
    }
}
