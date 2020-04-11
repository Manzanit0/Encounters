using System;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Encounters.Pages.Locations
{
    public partial class NearbyChurchesPage : ContentPage
    {
        private ChurchLocationService ChurchLocationService { get; set; }

        public NearbyChurchesPage()
        {
            InitializeComponent();
            NearbyChurches.ItemsSource = new ObservableCollection<Church>();
        }

        protected override async void OnAppearing()
        {
            try
            {
                ChurchLocationService = new ChurchLocationService();
                var churches = await ChurchLocationService.FindNearbyChurches();
                NearbyChurches.ItemsSource = churches;
            }
            catch (Exception e)
            {
                await DisplayAlert("Alert", e.Message + " // " + e.InnerException?.Message, "OK");
            }
        }

        private async void OnChurchSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is Church church)) return;
            
            var supportsUri = await Launcher.CanOpenAsync("comgooglemaps://");

            if (supportsUri)
                await Launcher.OpenAsync($"comgooglemaps://?q={church.Latitude},{church.Longitude}({church.Name})");
            else
                await Map.OpenAsync(church.Latitude, church.Longitude, new MapLaunchOptions {Name = church.Name});
        }
    }
}