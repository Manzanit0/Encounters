using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Encounters.Pages.Today
{
    class TodayViewModel : INotifyPropertyChanged
    {
        public TodayViewModel()
        {
            LoadDailyInfoCommand = new Command(async () => await LoadDailyInfo());
        }

        public Command LoadDailyInfoCommand { get; }

        private CalendarDay _calendarDay;

        public CalendarDay CalendarDay
        {
            set
            {
                if (_calendarDay == value) return;
                _calendarDay = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CalendarDay"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("LiturgicalDay"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Celebration"));
            }
            get => _calendarDay;
        }

        private string _exception;

        public string Exception
        {
            set
            {
                if (_exception == value) return;
                _exception = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Exception"));
            }
            get => _exception;
        }

        public string Greeting
        {
            get
            {
                if (DateTime.Now.Hour < 12) return "Good morning!";
                if (DateTime.Now.Hour < 20) return "Good afternoon!";
                return "Good night!";
            }
        }

        public string LiturgicalDay =>
            CalendarDay == null ? "" : $"Day {CalendarDay.SeasonWeek} of {UppercaseFirst(CalendarDay.Season)}";

        public string Celebration =>
            CalendarDay == null ? "" : $"Today we celebrate {CalendarDay.Celebrations[0].Title}";

        public event PropertyChangedEventHandler PropertyChanged;

        private async Task LoadDailyInfo()
        {
            try
            {
                var service = new CalendarService();
                CalendarDay = await service.GetLiturgicDay();
            }
            catch (Exception e)
            {
                Exception = e.Message;
            }
        }
        
        static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}