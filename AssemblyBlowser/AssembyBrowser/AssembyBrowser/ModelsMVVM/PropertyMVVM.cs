using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssembyBrowser.ModelsMVVM
{
    public class PropertyMVVM :Base
    {
        private string _propertyName = "";
        private string _typeName = "";

        public string PropertyName
        {
            get => _propertyName;
            set
            {
                _propertyName = value;
                OnPropertyChanged("PropertyName");
            }
        }
        public string PropertyTypeName
        {
            get => _typeName;
            set
            {
                _typeName = value;
                OnPropertyChanged("PropertyTypeName");
            }
        }
    }
}
