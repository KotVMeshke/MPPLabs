using MPP_LABA1_Console.Writer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_LABA1_Console.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void Write(params string[] text)
        {
            Console.WriteLine(text[0]);
        }
    }
}
