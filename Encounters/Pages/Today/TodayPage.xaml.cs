using Xamarin.Forms;

namespace Encounters.Pages.Today
{
    public partial class TodayPage : ContentPage
    {
        private TodayViewModel _viewModel;
        private TodayViewModel ViewModel => _viewModel ??= BindingContext as TodayViewModel;

        public TodayPage()
        {
            BindingContext = new TodayViewModel();
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.LoadDailyInfoCommand.Execute(null);
        }
    }
}