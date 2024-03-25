using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tracer.Data;
using Tracer.Tracers.Interface;

namespace Tracer.Tracers
{
    public class Tracer : ITracer
    {
        private TraceData _traceResult;

        public Tracer()
        {
            _traceResult = new TraceData();
            _traceResult.AddNewThread(new ThreadData(Thread.CurrentThread.ManagedThreadId));
        }

        public void StartTrace()
        {
            var StackTrace = new StackTrace();
            MethodData method = new MethodData(StackTrace.GetFrame(1)?.GetMethod()?.Name, StackTrace.GetFrame(1)?.GetMethod()?.DeclaringType?.Name);
            if (_traceResult._trace.ContainsKey(Thread.CurrentThread.ManagedThreadId))
                _traceResult.AddMethodToThread(Thread.CurrentThread.ManagedThreadId, method);
            else
            {
                _traceResult.AddNewThread(new ThreadData(Thread.CurrentThread.ManagedThreadId));
                _traceResult.AddMethodToThread(Thread.CurrentThread.ManagedThreadId, method);

            }
        }

        public void StopTrace()
        {
            MethodData? method = _traceResult.GetMethod(Thread.CurrentThread.ManagedThreadId);
        }

        public TraceResult GetTraceResult()
        {
            return new TraceResult(_traceResult);
        }
    }
}
