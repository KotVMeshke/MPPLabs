using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections.Concurrent;

namespace TracerSpace.Data
{
    public class TraceData
    {
        public ConcurrentDictionary<int, ThreadData> _trace;
        public TraceData()
        {
            _trace = new ConcurrentDictionary<int, ThreadData>();
        }

        public void AddNewThread(ThreadData threadData)
        {
            _trace.TryAdd(threadData.ThreadId, threadData);
        }

        public MethodData? GetMethod(int ThreadId)
        {
            if (_trace.TryGetValue(ThreadId, out ThreadData? threadData))
                return threadData.PopMethod();
            else
                return null;
        }

        public void AddMethodToThread(int ThreadId, MethodData methodData)
        {
            if (_trace.TryGetValue(ThreadId, out ThreadData? threadData))
                threadData.AddMethodToThread(methodData);
        }

    }
}
