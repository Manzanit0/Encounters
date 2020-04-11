using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Encounters.Pages.Today
{
    public class CalendarService
    {
        private static readonly HttpClient Client;
        
        static CalendarService()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("http://calapi.inadiutorium.cz"),
            };
        }
        public async Task<CalendarDay> GetLiturgicDay()
        {
            var response = await Client.GetAsync("/api/v0/en/calendars/default/today");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<CalendarDay>(responseBody);
        }
    }
}