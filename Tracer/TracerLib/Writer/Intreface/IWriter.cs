﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_LABA1_Console.Writer.Interface
{
    internal interface IWriter
    {
        void Write(params string[] text);
    }
}
