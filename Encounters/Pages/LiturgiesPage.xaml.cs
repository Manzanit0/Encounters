using System.Collections.Generic;
using Encounters.Models;
using Xamarin.Forms;

namespace Encounters.Pages
{
    public partial class LiturgyEntryPage : ContentPage
    {
        public LiturgyEntryPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            ListView.ItemsSource = new List<Prayer>
            {
                new Prayer{Name = "Our Father", Content = "Our Father, who art in heaven, (...)"},
                new Prayer{Name = "Hail Mary", Content = "Hail Mary, mother of God, (...)"},
            };
        }
        
        private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new LiturgyDisplayPage
                {
                    BindingContext = e.SelectedItem as Prayer
                });
            }
        }
    }
}