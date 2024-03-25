using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerSpace.Serializer.Interface
{
    internal interface ISerializer<T>
    {
        string Serialize(T obj);
    }
}
