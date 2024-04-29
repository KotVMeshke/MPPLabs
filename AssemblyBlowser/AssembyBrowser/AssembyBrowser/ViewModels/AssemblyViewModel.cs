using AssembyBrowser.AssemblyBrowser;
using AssembyBrowser.Command;
using AssembyBrowser.Models;
using AssembyBrowser.ModelsMVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AssembyBrowser.ViewModels
{
    public class AssemblyViewModel : INotifyPropertyChanged
    {
        private Base? selectedBase;

        public ObservableCollection<NamespaceMVVM>? Namespaces { get; set; }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      Console.WriteLine("new");
                      AssemblyBrowserCore browser = new AssemblyBrowserCore();
                      browser.BrowseAssembly(@"C:\Users\dimon\OneDrive\Рабочий стол\Study\Универ\Курс 3\Семестр 6\СПП\Labs\AssemblyBlowser\AssembyBrowser\AssemblyBrowserLib\bin\Debug\net8.0\AssemblyBrowserLib.dll");

                      DisplayAssembly(browser);
                      OnPropertyChanged("Namespaces");
                  }));
            }
        }
        public Base? SelectedBase
        {
            get { return selectedBase; }
            set
            {
                selectedBase = value;
                OnPropertyChanged("SelectedBase");
            }
        }

        public AssemblyViewModel()
        {
            
        }

        public AssemblyViewModel(AssemblyBrowserCore assemblyBrowser)
        {
            DisplayAssembly(assemblyBrowser);
        }
        private List<PropertyMVVM> ToMVVMProperty(List<Property> list)
        {
            var newList = new List<PropertyMVVM>();
            foreach (var property in list)
            {
                newList.Add(new PropertyMVVM() { PropertyName = property.Name, BaseName = property.Name, PropertyTypeName = property.Type });
            }

            return newList;
        }
        private List<FieldMVVM> ToMVVMField(List<Field> list)
        {
            var newList = new List<FieldMVVM>();
            foreach (var field in list)
            {
                newList.Add(new FieldMVVM() { FieldName = field.Name, BaseName = field.Name, FieldTypeName = field.Type});
            }

            return newList;
        }
        private List<MethodMVVM> ToMVVMMethod(List<Method> list)
        {
            var newList = new List<MethodMVVM>();
            foreach (var method in list)
            {
                newList.Add(new MethodMVVM() { MethodName = method.MethodName, BaseName = method.MethodName, Parameters = string.Join(',', method.Parameters),ReturnType = method.ReturnType });
            }

            return newList;
        }
        private ObservableCollection< TypeMVVM> ToMVVMType(Dictionary<string, Models.Type> dictionary)
        {
            var newDictionary = new ObservableCollection<TypeMVVM>();
            foreach(var type in dictionary)
            {
                newDictionary.Add(new TypeMVVM()
                {
                    TypeName = type.Value.TypeName,
                    Methods = ToMVVMMethod(type.Value.Methods),
                    Fields = ToMVVMField(type.Value.Fields),
                    Properties = ToMVVMProperty(type.Value.Properties)
                }) ;
            }

            return newDictionary;
        }
        public void DisplayAssembly(AssemblyBrowserCore assemblyBrowser)
        {
            var list = assemblyBrowser.Convert();
            Namespaces = new ObservableCollection<NamespaceMVVM>();

            foreach (var namsp in list)
            {
                Namespaces.Add(new NamespaceMVVM() { Name = namsp.NamespaceName, Types = ToMVVMType(namsp.Types) });
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
