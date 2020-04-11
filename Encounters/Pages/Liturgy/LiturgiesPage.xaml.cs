using System.Collections.Generic;
using Encounters.Models;
using Xamarin.Forms;

namespace Encounters.Pages.Liturgy
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
                new Prayer {Name = "Our Father", Content = OurFather()},
                new Prayer {Name = "The Hail Mary", Content = TheHailMary()},
                new Prayer {Name = "The Angelus", Content = TheAngelus()},
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

        private string OurFather()
        {
            return @"
Our Father who art in heaven,
hallowed be thy name.
Thy kingdom come.
Thy will be done 
on earth, as it is in heaven.
Give us this day 
our daily bread,
and forgive us our trespasses, 
as we forgive those who trespass against us,
and lead us not into temptation,
but deliver us from evil.";
        }

        private string TheHailMary()
        {
            return @"
Hail, Mary, full of grace,
the Lord is with thee.
Blessed art thou amongst women
and blessed is the fruit of thy womb, Jesus.
Holy Mary, Mother of God,
pray for us sinners,
now and at the hour of our death. 
Amen.";
        }

        private string TheAngelus()
        {
            return @"
The Angel of the Lord declared unto Mary,
And she conceived of the Holy Spirit.
Hail Mary…

Behold the handmaid of the Lord,
Be it done unto me according to your Word.
Hail Mary…

And the Word was made flesh,
And dwelt among us.
Hail Mary…

Pray for us, O holy Mother of God,
That we may be made worthy of the promises of Christ.";
        }
    }
}