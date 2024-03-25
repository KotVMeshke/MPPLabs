using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerSpace.Writer.Interface
{
    public interface IWriter
    {
        void Write(params string[] text);
    }
}
