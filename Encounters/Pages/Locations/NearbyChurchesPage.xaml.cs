using System;
using System.Collections.ObjectModel;
using Encounters.Churches;
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
                await DisplayAlert ("Alert", e.Message + " // " + e.InnerException?.Message, "OK");
            }
        }
    }
}