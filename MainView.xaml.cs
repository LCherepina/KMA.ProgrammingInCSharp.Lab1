
using System.Windows;

namespace KMA.ProgrammingInCSharp.Lab1
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView 
    {
        private MainViewViewModel _mainViewViewModel;
        public MainView()
        {
            InitializeComponent();
            Initialize();
            
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainViewViewModel = new MainViewViewModel();
            DataContext = _mainViewViewModel;
        }
    }
}
