using FakerLab.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Entities
{
    public class BarWithInner
    {
        public string? String { get; set; }
        public int Int { get; set; }
        public float Float { get; set; }
        public double Double;
        public decimal Decimal;
        public List<int>? List;
        public DateTime DateTime { get; set; }
        public Foo? Foo;
    }
}
