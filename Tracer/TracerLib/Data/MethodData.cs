using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TracerSpace.Data
{
    [Serializable]
    public class MethodData
    {
        [XmlAttribute("name")]
        [JsonProperty("name")]
        public string? Method;

        [XmlAttribute("class")]
        [JsonProperty("class")]
        public string? Class;

        [XmlAttribute("time")]
        [JsonProperty("time")]
        public string TimeWithText;

        [XmlElement("method")]
        [JsonProperty("methods")]
        public List<MethodData> Methods;

        [JsonIgnore]
        [XmlIgnore]
        public long Time;
        [JsonIgnore]
        [XmlIgnore]
        private Stopwatch? _watch;

        [JsonIgnore]
        [XmlIgnore]
        public int _numberInList;

        public MethodData()
        {
            Methods = new List<MethodData>();
            Method = "Base";
            Class = "Base";
            TimeWithText = "0ms";
        }
        public MethodData(string? Method, string? Class)
        {
            this.Method = Method;
            this.Class = Class;
            Methods = new List<MethodData>();
            TimeWithText = "0ms";
        }

        public void StartTimer()
        {
            _watch = Stopwatch.StartNew();
        }

        public void StopTimer()
        {
            if (_watch != null)
            {
                _watch.Stop();
                Time = _watch.ElapsedMilliseconds;
                TimeWithText = Time + "ms";
            }
        }
    }
}
