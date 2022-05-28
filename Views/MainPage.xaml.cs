using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using RSS_Reader.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.Web.Http;
using CodeHollow.FeedReader;
using Windows.UI.Xaml;

namespace RSS_Reader.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();
        public string Url { get { return Link.Text; } set { Link.Text = value; } }
        public string Button1x { set { Button1.Text = value; } }

        public MainPage()
        {
            InitializeComponent();
        }

        public async Task ReadRSS()
        {
            var feed = await FeedReader.ReadAsync(Url);
            Button1x = feed.Title;
            foreach (FeedItem item in feed.Items)
            {
                // Create a new button
                Button newButton = new Button();

                // Set Button title
                newButton.Content = item.Title;

                // Button size
                newButton.Width = 770;
                newButton.Height = 330;
                newButton.FontSize = 30;

                // Set button margin
                Thickness margin = newButton.Margin;
                //newButton.Margin.Down = 10;
                newButton.Margin = margin;

                // Add other info
                

                // Set button to stackpanel
                ButtonPanel.Children.Add(newButton);
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            _ = ReadRSS();
        }

        private void Link_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ = ReadRSS();
        }
    }
}
