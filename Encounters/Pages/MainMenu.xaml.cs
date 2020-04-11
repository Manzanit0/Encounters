using System;
using System.Collections.Generic;
using Encounters.Models;
using Encounters.Pages.About;
using Encounters.Pages.Liturgy;
using Encounters.Pages.Locations;
using Encounters.Pages.Thoughts;
using Encounters.Pages.Today;
using Xamarin.Forms;

namespace Encounters.Pages
{
    public partial class MainMenu : MasterDetailPage
    {
        public List<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            BindingContext = this;

            MainMenuItems = new List<MainMenuItem>()
            {
                new MainMenuItem {Title = "Today", Icon = IconFont.Calendar, TargetType = typeof(TodayPage)},
                new MainMenuItem {Title = "Liturgy", Icon = IconFont.BookCross, TargetType = typeof(LiturgyEntryPage)},
                new MainMenuItem {Title = "Nearby Churches", Icon = IconFont.MapMarkerRadius, TargetType = typeof(NearbyChurchesPage)},
                new MainMenuItem {Title = "Thoughts", Icon = IconFont.LeadPencil, TargetType = typeof(NotesPage)},
                new MainMenuItem {Title = "About", Icon = IconFont.InformationOutline, TargetType = typeof(AboutPage)},
            };

            Detail = new NavigationPage(new TodayPage());

            InitializeComponent();
        }

        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(e.SelectedItem is MainMenuItem item)) return;
            
            Detail = new NavigationPage((Page) Activator.CreateInstance(item.TargetType));
            MenuListView.SelectedItem = null;
            IsPresented = false;
        }
    }
}