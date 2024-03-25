using TracerSpace.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TracerSpace.Tracers
{
    [XmlRoot("root")]
    [Serializable]
    public class TraceResult
    {
        [XmlElement("thread")]
        [JsonProperty("threads")]
        public List<ThreadData> _trace;

        public TraceResult(TraceData data)
        {
            _trace = data._trace.Values.ToList();
        }
        public TraceResult()
        {

        }
    }
}
