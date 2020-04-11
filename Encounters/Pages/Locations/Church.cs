namespace Encounters.Pages.Locations
{
    public class Church
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int MetersAway { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        // TODO viewmodel :-)
        public string MetersAwayView => $"{MetersAway}m away";
    }
}