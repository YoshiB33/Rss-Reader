using System.Threading.Tasks;
using RSS_Reader.ViewModels;

using Windows.UI.Xaml.Controls;
using CodeHollow.FeedReader;
using Windows.UI.Xaml;

namespace RSS_Reader.Views
{
    /// <summary>
    /// Makes the main page work
    ///
    /// Initializes components and updates things
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Initializes ViewModel
        public MainViewModel ViewModel { get; } = new MainViewModel();

        /// <summary>
        /// Initalizes strings
        /// </summary>
        
        // String for URL TextBox
        public string Url { get { return Link.Text; } set { Link.Text = value; } }
        // String for Title TextBlock
        public string Title { set { TitleBox.Text = value; } }

        // Initializes Mainpage
        public MainPage()
        {
            InitializeComponent();
        }

        public async Task ReadRSS()
        {
            // Reads the feed and writes title
            var feed = await FeedReader.ReadAsync(Url);
            Title = feed.Title;

            // Makes a new button per item in xml feed
            foreach (FeedItem item in feed.Items)
            {
                // Create a new button
                Button newButton = new Button();

                // Button size
                newButton.Height = 330;
                newButton.Width = 750;

                // Font size
                newButton.FontSize = 20;

                // Set button margin
                newButton.Margin = new Thickness(0,10,0,10);

                /// Add info
                // Stackpanel
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Vertical;
                stackPanel.Margin = new Thickness(10);
                newButton.Content = stackPanel;


                // Add title text
                TextBlock newTitleTextBlock = new TextBlock();
                newTitleTextBlock.FontSize = 18;
                newTitleTextBlock.Text = item.Title;
                newTitleTextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                newTitleTextBlock.VerticalAlignment = VerticalAlignment.Center;
                newTitleTextBlock.Margin = new Thickness(0,10,0,0);
                newTitleTextBlock.TextWrapping = TextWrapping.Wrap;
                stackPanel.Children.Add(newTitleTextBlock);

                // Add description text
                TextBlock newDescriptionTextBlock = new TextBlock();
                newDescriptionTextBlock.Text = item.Description;
                newDescriptionTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
                newDescriptionTextBlock.VerticalAlignment = VerticalAlignment.Bottom;
                newDescriptionTextBlock.FontSize = 13;
                newDescriptionTextBlock.TextWrapping = TextWrapping.Wrap;
                stackPanel.Children.Add(newDescriptionTextBlock);

                // Add Date/Time Textblock
                TextBlock newDateTextblock = new TextBlock();
                newDateTextblock.FontSize = 10;
                newDateTextblock.Text = item.PublishingDateString;
                newDateTextblock.HorizontalAlignment = HorizontalAlignment.Center;
                newDateTextblock.VerticalAlignment = VerticalAlignment.Bottom;
                stackPanel.Children.Add(newDateTextblock);

                // Set button to stackpanel
                ButtonPanel.Children.Add(newButton);
            }
        }

        // When the button is pressed the feed is updated
        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            // Updates the feed
            _ = ReadRSS();
        }

        // When the link changes the feed update
        private void Link_TextChanged(object sender, TextChangedEventArgs e)
        {
            _ = ReadRSS();
        }


    }
}
