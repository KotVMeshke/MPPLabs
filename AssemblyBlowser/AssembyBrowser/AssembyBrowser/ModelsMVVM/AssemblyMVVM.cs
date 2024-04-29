using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssembyBrowser.ModelsMVVM
{
    public class AssemblyMVVM : INotifyPropertyChanged
    {
        private string _path = "";
        private Dictionary<string, NamespaceMVVM> _namespaces = [];

        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                OnPropertyChanged("AssemblyPath");
            }
        }

        public Dictionary<string, NamespaceMVVM> Namespaces
        {
            get => _namespaces;
            set
            {
                _namespaces = value;
                OnPropertyChanged("Namespaces");
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
