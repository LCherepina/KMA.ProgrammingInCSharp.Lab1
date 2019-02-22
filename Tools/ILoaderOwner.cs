using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp.Lab1.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
