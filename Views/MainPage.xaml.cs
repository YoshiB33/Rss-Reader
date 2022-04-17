using System;

using RSS_Reader.ViewModels;

using Windows.UI.Xaml.Controls;

namespace RSS_Reader.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
