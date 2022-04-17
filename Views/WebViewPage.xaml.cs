using System;

using RSS_Reader.ViewModels;

using Windows.UI.Xaml.Controls;

namespace RSS_Reader.Views
{
    public sealed partial class WebViewPage : Page
    {
        public WebViewViewModel ViewModel { get; } = new WebViewViewModel();

        public WebViewPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
