using System;
using System.Collections.Generic;
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
                new MainMenuItem {Title = "Liturgy", Icon = IconFont.BookCross, TargetType = typeof(NotesPage)},
                new MainMenuItem {Title = "Mass", Icon = IconFont.Church, TargetType = typeof(NotesPage)},
                new MainMenuItem {Title = "Thoughts", Icon = IconFont.LeadPencil, TargetType = typeof(NotesPage)},
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new NotesPage());

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

                if (item.Title.Equals("Mass"))
                {
                    Detail = new NavigationPage(new NotesPage());
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

    public class MainMenuItem
    {
        public string Title { get; set; }
        public string Icon { get; set; }
        public Type TargetType { get; set; }
    }

    internal static class IconFont
    {
        public const string BookCross = "\U000f00a2";
        public const string Church = "\U000f0144";
        public const string LeadPencil = "\U000f064f";
    }
}