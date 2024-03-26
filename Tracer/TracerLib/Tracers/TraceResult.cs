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
        public List<ThreadData>? _trace;

        public TraceResult(TraceData data)
        {
            _trace = data._trace.Values.ToList();
        }
        public TraceResult(List<ThreadData> threadData)
        {
            _trace = threadData;
        }

        public TraceResult() { }

        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != typeof(TraceResult))
            {
                return false;
            }

            TraceResult traceResult = (TraceResult)obj;
            return _trace!.SequenceEqual(traceResult._trace);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            foreach (var threadTraceInfo in _trace)
            {
                hash = unchecked((7 * hash) + threadTraceInfo.GetHashCode());
            }

            return hash;
        }
    }
}
