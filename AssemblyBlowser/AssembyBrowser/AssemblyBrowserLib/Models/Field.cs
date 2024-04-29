using System.Collections;
using System.Reflection;

namespace AssembyBrowser.Models
{
    public class Field
    {
        private string _fieldName = "";
        private string _fieldType = "";

        public string Type
        {
            get => _fieldType;
            set => _fieldType = value;
        }
        public string Name
        {
            get => _fieldName;
            set => _fieldName = value;
        }

        public Field(FieldInfo fieldInfo)
        {
            CreateFiledInfo(fieldInfo);
        }

        private void CreateFiledInfo(FieldInfo fieldInfo)
        {
            
            if (fieldInfo.FieldType.IsGenericType)
            {
                var generics = fieldInfo.FieldType.GetGenericArguments();
                _fieldType = fieldInfo.FieldType.Name.Remove(fieldInfo.FieldType.Name.IndexOf('`')) + "<";
                foreach (var generic in generics)
                {
                    _fieldType += generic.Name + ",";
                }
                if (_fieldType[^1] == ',')
                    _fieldType = _fieldType.Remove(_fieldType.Length - 1);
                _fieldType += ">";
            }
            else
            {
                _fieldType = fieldInfo.FieldType.Name;
            }
            _fieldName = fieldInfo.Name;
        }

        public override string? ToString()
        {
            return $"Field name: {Name}, Type: {Type}\n";
        }
    }
}
