using AssembyBrowser.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssembyBrowser.ModelsMVVM
{
    public class TypeMVVM : INotifyPropertyChanged
    {
        private List<PropertyMVVM> _properties = [];
        private List<MethodMVVM> _methods = [];
        private List<FieldMVVM> _fields = [];

        private List<Base> bases = [];
        private string _typeName = "sdfsd";

        public List<PropertyMVVM> Properties
        {
            get => _properties;
            set => _properties = value;
        }

        public List<MethodMVVM> Methods
        {
            get => _methods;
            set
            {
                _methods = value;
                OnPropertyChanged("Methods");
            }
        }
        public List<FieldMVVM> Fields
        {
            get => _fields;
            set
            {
                _fields = value;
                OnPropertyChanged("Fields");
            }
        }

        public string TypeName
        {
            get => _typeName;
            set
            {
                _typeName = value;
                OnPropertyChanged("TypeName");
            }
        }

       
        public IEnumerable<Base> Bases
        {
            get
            {
                bases = [];
                bases.AddRange(_methods);
                bases.AddRange(_fields);
                bases.AddRange(_properties);
                return bases;
                    
            }
            set
            {
                bases = value.ToList();
                OnPropertyChanged("Bases");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
