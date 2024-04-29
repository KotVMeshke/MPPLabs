using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace AssembyBrowser.Models
{
    public class Method
    {
        private string _methodName = "";
        private List<string> _parameters = [];
        private string _returnType = "";

        public string MethodName
        {
            get => _methodName;
            set => _methodName = value;
        }
        public List<string> Parameters
        {
            get => _parameters;
            set => _parameters = value;
        }
        public string ReturnType
        {
            get => _returnType;
            set => _returnType = value;
        }

        public Method(MethodInfo methodInfo)
        {
            CreateMethodInfo(methodInfo);
        }

        public static bool CheckIfExtending(MethodInfo methodInfo) => methodInfo.IsStatic && methodInfo.IsDefined(typeof(ExtensionAttribute));


        private void CreateMethodInfo(MethodInfo methodInfo)
        {
            if (methodInfo.ReturnParameter.ParameterType.IsGenericType)
            {
                var generics = methodInfo.ReturnType.GetGenericArguments();
                _returnType = Type.CreateGenericName(generics, methodInfo.ReturnType.Name);

            }else
            {
                _returnType = methodInfo.ReturnParameter.ParameterType.Name;

            }

            if (methodInfo.IsGenericMethod)
            {
                var generics = methodInfo.GetGenericArguments();
                _methodName = Type.CreateGenericName(generics, methodInfo.Name);

            }
            else
            {
                _methodName = methodInfo.Name;
            }

            var parameters = methodInfo.GetParameters();

            foreach (var param in parameters)
            {
                string result = param.ParameterType.Name;
                if (param.ParameterType.IsGenericType)
                    result = Type.CreateGenericName(param.ParameterType.GetGenericArguments(), param.ParameterType.Name ?? " ");
                _parameters.Add(result);
            }
        }

        public override string? ToString()
        {
            return $"Method name: {MethodName}, Parametrs: {string.Join('\n', Parameters)}, Return type: {ReturnType}\n ";
        }
    }
}
