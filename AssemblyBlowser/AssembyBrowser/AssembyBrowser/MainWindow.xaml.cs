using System.Reflection;
using System.Windows;
using AssembyBrowser.AssemblyBrowser;
using AssembyBrowser.ModelsMVVM;
using AssembyBrowser.ViewModels;

namespace AssembyBrowser
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AssemblyViewModel viewModel;
        public MainWindow()
        {
            InitializeComponent();

            
            var assemblyBrowser = new AssemblyBrowserCore();
            //assemblyBrowser.BrowseAssembly(@"C:\Users\dimon\OneDrive\Рабочий стол\Study\Универ\Курс 3\Семестр 6\СПП\Labs\AssemblyBlowser\AssembyBrowser\AssemblyBrowserLib\bin\Debug\net8.0\AssemblyBrowserLib.dll");
            assemblyBrowser.BrowseAssembly(Assembly.GetExecutingAssembly().Location);
            
                viewModel = new AssemblyViewModel(assemblyBrowser);
            DataContext = viewModel;

        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (e.NewValue is Base selectedBase)
            {
                Console.WriteLine(selectedBase.BaseName);
                viewModel.SelectedBase = selectedBase;
                
            }
        }
    }
}