using System.Reflection;

namespace AssembyBrowser.Models
{
    public class Property
    {
        private string _name = "";
        private string _type = "";
        public string Type
        {
            get => _type;
            set => _type = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public Property(PropertyInfo propertyInfo)
        {
            CreateProperty(propertyInfo);
        }

        private void CreateProperty(PropertyInfo propertyInfo)
        {
            _name = propertyInfo.Name;
            if (propertyInfo.PropertyType.IsGenericType)
            {
                var generics = propertyInfo.PropertyType.GetGenericArguments();
                _type = propertyInfo.PropertyType.Name.Remove(propertyInfo.PropertyType.Name.IndexOf('`')) + "<";
                foreach (var generic in generics)
                {
                    _type += generic.Name + ",";
                }
                if (_type[^1] == ',')
                    _type = _type.Remove(_type.Length - 1);
                _type += ">";
            }
            else
            {
                _type = propertyInfo.PropertyType.Name;
            }
        }

        public override string? ToString()
        {
            return $"Property name: {Name}, Type: {Type}\n";
        }

    }
}
