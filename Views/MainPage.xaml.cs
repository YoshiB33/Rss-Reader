using System;
using System.Threading.Tasks;
using RSS_Reader.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.Web.Http;

namespace RSS_Reader.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        public string URI = "https://www.svt.se/nyheter/rss.xml";

        public MainPage()
        {
            InitializeComponent();
        }
        class getHttp
        {
            
        }
    }
}
