using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Classes
{
    internal class Foo
    {
        public string? String { get; set; }
        public int Int { get; set; }
        public float Float { get; set; }
        public double Double;
        public decimal Decimal;
        public List<int>? List;
        public DateTime DateTime { get; set; }

        public override string? ToString()
        {
            return $"String: {String}\nInt: {Int}\nFloat: {Float}\nDouble: {Double}\nDecimal: {Decimal}\nList: {string.Join(' ',List)}\nDateTime: {DateTime}";
        }
    }
}
