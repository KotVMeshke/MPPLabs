using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssembyBrowser.ModelsMVVM
{
    public class Base : INotifyPropertyChanged
    {

        private string _baseName = " ";
        public string BaseName
        {
            get => _baseName;
            set
            {
                _baseName = value;
                OnPropertyChanged("BaseName");
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
