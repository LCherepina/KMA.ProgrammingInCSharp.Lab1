namespace KMA.ProgrammingInCSharp.Lab1.Tools
{
   
internal class NavigationModel
{
    private readonly IContentWindow _contentWindow;
    private MainView _mainView;

    internal NavigationModel(IContentWindow contentWindow)
    {
        _contentWindow = contentWindow;
    }

    internal void Navigate()
    {
        _contentWindow.ContentControl.Content = (_mainView = new MainView());
    }
}
} 

