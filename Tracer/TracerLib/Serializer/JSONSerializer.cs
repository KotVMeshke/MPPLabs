using TracerSpace.Serializer.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TracerSpace.Serializer
{
    public class JSONSerializer<T> : ISerializer<T>
    {

        public string Serialize(T obj)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };
            string json = JsonConvert.SerializeObject(obj, settings);
            return json;
        }
    }
}
