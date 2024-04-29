using System.Reflection;
using System.Xml.Linq;

namespace AssembyBrowser.Models
{
    public class Namespace
    {
        private Dictionary<string,Type> _types = [];
        private string _namespaceName = "";

        public string NamespaceName
        {
            get => _namespaceName;
            set => _namespaceName = value;
        }
        public Dictionary<string, Type> Types
        {
            get => _types;
            set => _types = value;
        }

        public Namespace(string namespaceName)
        {
            _namespaceName = namespaceName;
        }

        private void CreateExtendsTypes(List<MethodInfo> methods)
        {
            foreach (var method in methods)
            {
                var type =method?.GetParameters()[0].ParameterType;
                string typeName = type.Name;
                if (type.IsGenericType)
                {
                    var generics = type.GetGenericArguments();
                    typeName = type.Name.Remove(type.Name.IndexOf('`')) + "<";
                    foreach (var generic in generics)
                    {
                        typeName += generic.Name + ",";
                    }
                    if (typeName[^1] == ',')
                        typeName = typeName.Remove(typeName.Length - 1);
                    typeName += ">";
                }
                else
                {
                    typeName = type.Name;
                }
                if (!_types.ContainsKey(typeName))
                {
                    _types.Add(typeName, new Type(type, out _, true));
                }
                _types[typeName].AddExtendingMethod(method!);

            }
        }

        public void AddType(System.Type typeInfo)
        {
            _types.Add(typeInfo.Name,new Type(typeInfo, out var methods, false));
            CreateExtendsTypes(methods);
        }

        public override string? ToString()
        {
            return $"Namesace name: {NamespaceName}, Types: {string.Join('\n',Types)}\n";
        }


    }
}
