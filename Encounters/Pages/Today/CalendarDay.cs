using System;
using Newtonsoft.Json;

namespace Encounters.Pages.Today
{
    public class CalendarDay
    {
        [JsonProperty("date")]
        public DateTimeOffset Date { get; set; }

        [JsonProperty("season")]
        public string Season { get; set; }

        [JsonProperty("season_week")]
        public long SeasonWeek { get; set; }

        [JsonProperty("celebrations")]
        public Celebration[] Celebrations { get; set; }

        [JsonProperty("weekday")]
        public string Weekday { get; set; }
    }
    
    public class Celebration
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("colour")]
        public string Colour { get; set; }

        [JsonProperty("rank")]
        public string Rank { get; set; }

        [JsonProperty("rank_num")]
        public double RankNum { get; set; }
    }
}