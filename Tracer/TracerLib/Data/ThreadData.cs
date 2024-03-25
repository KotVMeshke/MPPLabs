using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Tracer.Data
{

    [Serializable]
    public class ThreadData
    {
        [XmlAttribute("id")]
        [JsonProperty("id")]
        public int ThreadId;

        [JsonIgnore]
        [XmlIgnore]
        public long Time;
        [XmlAttribute("time")]
        [JsonProperty("time")]
        public string TimeWithText;

        [XmlElement("method")]
        [JsonProperty("methods")]
        public List<MethodData> Methods;
        [JsonIgnore]
        [XmlIgnore]
        private Stack<MethodData> _traceStack;

        [XmlIgnore]
        [JsonIgnore]
        private int _lastNumber;

        [XmlIgnore]
        [JsonIgnore]
        private int _currentNumber;

        public ThreadData()
        {
            _traceStack = new Stack<MethodData>();
            Methods = new List<MethodData>();
            TimeWithText = "0ms";
        }

        public ThreadData(int ThreadId)
        {
            _traceStack = new Stack<MethodData>();
            Methods = new List<MethodData>();
            this.ThreadId = ThreadId;
            TimeWithText = "0ms";
        }

        public void AddMethodToThread(MethodData MethodData)
        {
            PushMethod(MethodData);
        }

        public void AddMethodToList(List<MethodData> methods, MethodData method)
        {
            foreach (var element in methods)
            {
                if (element.Methods.Count != 0)
                {
                    AddMethodToList(element.Methods, method);
                }

                if (element._numberInList == _currentNumber)
                {
                    element.Methods.Add(method);
                }

            }
        }

        public void GetThreadTime()
        {

            Time += Methods[^1].Time;

            TimeWithText = Time + "ms";
        }

        public void PushMethod(MethodData method)
        {
            method._numberInList = _lastNumber++;
            if (_traceStack.Count == 0)
            {
                Methods.Add(method);
            }
            else
            {
                _currentNumber = _traceStack.Peek()._numberInList;

                AddMethodToList(Methods, method);

            }
            _traceStack.Push(method);

            method.StartTimer();
        }

        public MethodData PopMethod()
        {
            MethodData method = _traceStack.Pop();
            method.StopTimer();
            if (_traceStack.Count == 0)
                GetThreadTime();
            return method;
        }


    }
}
