
using System.Windows.Controls;
using KMA.ProgrammingInCSharp.Lab1.Managers;
using KMA.ProgrammingInCSharp.Lab1.Tools;
using KMA.ProgrammingInCSharp.Lab1.ViewModels;

namespace KMA.ProgrammingInCSharp.Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: IContentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();


        }



        public ContentControl ContentControl
              {
            get { return _contentControl; }
        }
    }
}
