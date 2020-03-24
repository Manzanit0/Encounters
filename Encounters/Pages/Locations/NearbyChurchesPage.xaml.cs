using System.Collections.Generic;
using Xamarin.Forms;

namespace Encounters.Pages.Locations
{
    public partial class NearbyChurchesPage : ContentPage
    {
        public NearbyChurchesPage()
        {
            InitializeComponent();
            
            NearbyChurches.ItemsSource = new List<Church>
            {
                new Church
                {
                    Name = "Church of the Transfiguration",
                    Address = "1 Wrentham Ave, London",
                    Website = "https://www.transfigparishkensalrise.org.uk/",
                    MetersAway = 349
                },
                new Church
                {
                    Name = "St Mary Magdalen R C Church",
                    Address = "1 Peter Ave, London",
                    Website = "N/A",
                    MetersAway = 876
                },
                new Church
                {
                    Name = "Parish Church of St Andrew",
                    Address = "The Clergy House, St Andrews Rd, London",
                    Website = "N/A",
                    MetersAway = 1452
                },
            };
        }
    }

    public class Church
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public int MetersAway { get; set; }
        
        // TODO viewmodel :-)
        public string MetersAwayView => $"{MetersAway}m away";
    }
}