using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssembyBrowser.ModelsMVVM
{
    public class MethodMVVM : Base
    {
        private string _methodName = "";
        private string _parameters = "";
        private string _returnType = "";

        public string MethodName
        {
            get => _methodName;
            set
            {
                _methodName = value;
                OnPropertyChanged("MethodName");
            }
        }
        public string Parameters
        {
            get => _parameters;
            set
            {
                _parameters = value;
                OnPropertyChanged("Parameters");
            }
        }
        public string ReturnType
        {
            get => _returnType;
            set
            {
                _returnType = value;
                OnPropertyChanged("ReturnType");
            }
        }

       
    }
}
