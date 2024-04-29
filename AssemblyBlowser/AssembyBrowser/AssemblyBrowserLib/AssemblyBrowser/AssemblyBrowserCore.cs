using AssembyBrowser.Models;
using System.Reflection;

namespace AssembyBrowser.AssemblyBrowser
{
    public class AssemblyBrowserCore
    {
        private Dictionary<string, Namespace> _namespaces = [];
        public AssemblyBrowserCore() { }

        public void BrowseAssembly(string assemblyPath)
        {
            var assembly = Assembly.LoadFrom(assemblyPath);
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                var namespaceType = type.Namespace ?? " ";
               if (!_namespaces.ContainsKey(namespaceType!))
                {
                    _namespaces.Add(namespaceType!, new Namespace(namespaceType));
                }

                _namespaces[namespaceType ?? " "].AddType(type);
            }
        }

        public void DrawHierarhy()
        {
            Console.WriteLine(string.Join('\n', _namespaces));
        }

        public IEnumerable<Namespace> Convert()
        {
            return [.. _namespaces.Values];
        }
    }
}
