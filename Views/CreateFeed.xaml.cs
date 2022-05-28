using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System;
using Windows.Storage;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using RSS_Reader.ViewModels;
using Windows.Data.Json;
using RSS_Reader.Helpers;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RSS_Reader.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class CreateFeed : Page
    {
        public string DisplayName
        { get { return DisplayNameTextBox.Text; } set { DisplayNameTextBox.Text = value; } }

        public string Consolle
        { get { return ConsolleJsonViewer.Text; } set { ConsolleJsonViewer.Text = value; } }

        public string Link
        {
            get => LinkTextBox.Text;
            set
            { LinkTextBox.Text = value; }
        }

        public CreateFeed()
        {
            InitializeComponent();
        }

        public void EraseBoxes()
        {
            DisplayNameTextBox.Text = string.Empty;
            LinkTextBox.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EraseBoxes();
        }

        private void LinkTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
    
}
