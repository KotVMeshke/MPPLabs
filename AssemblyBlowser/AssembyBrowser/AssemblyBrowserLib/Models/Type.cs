using AssembyBrowser.Models;
using System.Reflection;
using System.Xml.Linq;

namespace AssembyBrowser.Models;

public class Type
{
    private List<Property> _properties = [];
    private List<Method> _methods = [];
    private List<Field> _fields = [];
    
    private string _typeName = "";

    public List<Property> Properties
    {
        get => _properties;
        set => _properties = value;
    }

    public List<Method> Methods
    {
        get => _methods;
        set => _methods = value;
    }
    public List<Field> Fields
    {
        get => _fields;
        set => _fields = value;
    }

    public string TypeName
    {
        get => _typeName;
        set => _typeName = value;
    }
    public static string CreateGenericName(System.Type?[] generics, string name)
    {
        var result = name.Remove(name.IndexOf('`')) + "<";
        foreach (var generic in generics)
        {
            result += generic.Name + ",";
        }
        if (result[^1] == ',')
            result = result.Remove(result.Length - 1);
        result += ">";

        return result;
    }
    public Type(System.Type typeInfo, out List<MethodInfo> extends, bool extending)
    {
        if (extending)
        {
            CreateExtendingType(typeInfo);
            extends = new List<MethodInfo>();
            return;
        }
        extends = CreateType(typeInfo);
    }

    private void CreateExtendingType(System.Type typeInfo)
    {
        if (typeInfo.IsGenericType)
        {
            var generics = typeInfo.GetGenericArguments();
            _typeName = CreateGenericName(generics, typeInfo.Name);
        }
        else
        {
            _typeName = typeInfo.Name;
        }
    }

    private List<MethodInfo> CreateType(System.Type typeInfo)
    {
        if (typeInfo.IsGenericType)
        {
            var generics = typeInfo.GetGenericArguments();
          
            _typeName = CreateGenericName(generics, typeInfo.Name);
        }
        else
        {
            _typeName = typeInfo.Name;
        }
        var methods = typeInfo.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        var properties = typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        var fields = typeInfo.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        var extends = new List<MethodInfo>();
        foreach (var method in methods)
        {
            if (Method.CheckIfExtending(method))
            {
                extends.Add(method);
            }
            else 
            _methods.Add(new Method(method));
        }
        foreach (var field in fields)
        {
            _fields.Add(new Field(field));
        }
        foreach (var property in properties)
        {
            _properties.Add(new Property(property));
        }

        return extends;
    }

    public void AddExtendingMethod(MethodInfo method)
    {
        _methods.Add(new Method(method));
    }

    public override string? ToString()
    {
        return $"Type name: {TypeName}, Methods: {string.Join('\n', Methods)}, Properties: {string.Join('\n', Properties)}, Fields: {string.Join('\n', Fields)}\n";
    }
}
