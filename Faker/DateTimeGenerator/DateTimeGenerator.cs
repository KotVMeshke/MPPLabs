using FakerLab.Generators;
using System.Globalization;

namespace DateTimeGenerator
{
    public class DateTimeGenerator : IGenerator<DateTime>
    {
        private readonly Random _random = new Random();

        public DateTime GenerateValue()
        {
            int year = _random.Next(10000) + 1;

            int month = _random.Next(12) + 1;
            int maxDay = DateTime.DaysInMonth(year, month);

            int day = _random.Next(maxDay) + 1;
            int hour = _random.Next(24);
            int minute = _random.Next(60);
            int second = _random.Next(60);

            return new DateTime(year, month, day, hour, minute, second, CultureInfo.CurrentCulture.Calendar);
        }
    }
}
