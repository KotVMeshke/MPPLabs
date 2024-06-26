﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakerLab.Classes
{
    public class Foo
    {
        public int Int { get; set; }
        public float Float { get; set; }
        public double Double;
        public decimal Decimal;
        public List<int>? List;

        public override string? ToString()
        {
            return $"Int: {Int}\nFloat: {Float}\nDouble: {Double}\nDecimal: {Decimal}\nList: {string.Join(' ',List)}";
        }
    }
}
