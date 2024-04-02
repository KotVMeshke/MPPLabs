using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Classes
{
    public class BarWithPrivate
    {
        public string? String { get; set; }
        public int Int { get; set; }
        public float Float { get; set; }
        public double Double;
        public decimal Decimal;
        public List<int>? List;
        public DateTime DateTime { get; set; }

        private BarWithPrivate(int integer)
        {
            Int = integer;
            String = "Str";
        }
    }
}
