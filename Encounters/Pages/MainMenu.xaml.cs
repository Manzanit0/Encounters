using System.Collections.Generic;
using Encounters.Models;
using Encounters.Pages.Liturgy;
using Encounters.Pages.Locations;
using Encounters.Pages.Thoughts;
using Xamarin.Forms;

namespace Encounters.Pages
{
    public partial class MainMenu : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem {Title = "Liturgy", Icon = IconFont.BookCross, TargetType = typeof(LiturgyEntryPage)},
                new MainMenuItem {Title = "Nearby Churches", Icon = IconFont.MapMarkerRadius, TargetType = typeof(NearbyChurchesPage)},
                new MainMenuItem {Title = "Thoughts", Icon = IconFont.LeadPencil, TargetType = typeof(NotesPage)},
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new NearbyChurchesPage());

            InitializeComponent();
        }

        // When a MenuItem is selected.
        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MainMenuItem item)
            {
                if (item.Title.Equals("Liturgy"))
                {
                    Detail = new NavigationPage(new LiturgyEntryPage());
                }

                if (item.Title.Equals("Nearby Churches"))
                {
                    Detail = new NavigationPage(new NearbyChurchesPage());
                }
                else if (item.Title.Equals("Thoughts"))
                {
                    Detail = new NavigationPage(new NotesPage());
                }

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}