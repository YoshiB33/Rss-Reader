using System;

using RSS_Reader.ViewModels;
using Windows.ApplicationModel.Core;
using Windows.Globalization;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace RSS_Reader.Views
{
    // TODO WTS: Change the URL for your privacy policy in the Resource File, currently set to https://YourPrivacyUrlGoesHere
    public sealed partial class SettingsPage : Page
    {
        public SettingsViewModel ViewModel { get; } = new SettingsViewModel();

        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.InitializeAsync();
        }

        private void RadioButton_Checked(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ApplicationLanguages.PrimaryLanguageOverride = "en-us";
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
        }

        private void RadioButton_Checked_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ApplicationLanguages.PrimaryLanguageOverride = "sv-se";
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().Reset();
            Windows.ApplicationModel.Resources.Core.ResourceContext.GetForViewIndependentUse().Reset();
        }


        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var result = await CoreApplication.RequestRestartAsync("Application Restart Programmatically ");

            if (result == AppRestartFailureReason.NotInForeground ||
                result == AppRestartFailureReason.RestartPending ||
                result == AppRestartFailureReason.Other)
            {
                var msgBox = new MessageDialog("Restart Failed", result.ToString());
                await msgBox.ShowAsync();
            }
        }
    }
}
