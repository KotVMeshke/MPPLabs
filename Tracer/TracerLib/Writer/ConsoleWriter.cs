using TracerSpace.Writer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerSpace.Writer
{
    public class ConsoleWriter : IWriter
    {
        public void Write(params string[] text)
        {
            Console.WriteLine(text[0]);
        }
    }
}
