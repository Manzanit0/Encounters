namespace Encounters.Churches
{
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