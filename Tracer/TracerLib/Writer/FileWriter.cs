using MPP_LABA1_Console.Writer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP_LABA1_Console.Writer
{
    public class FileWriter : IWriter
    {
        public void Write(params string[] text)
        {
            if (text.Length == 2)
            {
                using var file = new StreamWriter(text[1], false);
                file.Write(text[0]);
            }else
            {
                throw new Exception("Incorrect parametrs count");
            }
        }
    }
}
