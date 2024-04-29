using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssembyBrowser.ModelsMVVM
{
    public class FieldMVVM : Base
    {
        private string _fieldName = "";
        private string _typeName = "";

        public string FieldName
        {
            get => _fieldName;
            set
            {
                _fieldName = value;
                OnPropertyChanged("FieldName");
            }
        }
        public string FieldTypeName
        {
            get => _typeName;
            set
            {
                _typeName = value;
                OnPropertyChanged("FieldTypeName");
            }
        }



    }
}
