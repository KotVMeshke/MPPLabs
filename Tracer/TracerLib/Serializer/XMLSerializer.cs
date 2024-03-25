using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using TracerSpace.Serializer.Interface;

namespace TracerSpace.Serializer
{
    public class XMLSerializer<T> : ISerializer<T>
    {
        public string Serialize(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            string xml = "";
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, obj);
                xml = writer.ToString();
            }

            return xml;
        }
    }
}
