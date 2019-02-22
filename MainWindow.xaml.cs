


namespace KMA.ProgrammingInCSharp.Lab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            MainView mainView = new MainView();

            Content = mainView;
        }
    }
}
