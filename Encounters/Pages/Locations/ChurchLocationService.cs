using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Encounters.Pages.Locations
{
    public class ChurchLocationService
    {
        private static readonly HttpClient Client;
        private static string TomtomApiToken = "TOMTOM-API-TOKEN-HERE";
        private static string TomtomApiChurchCategory = "7339002";

        static ChurchLocationService()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri("https://api.tomtom.com"),
            };
        }

        public async Task<IEnumerable<Church>> FindNearbyChurches()
        {
            // var location = await Geolocation.GetLastKnownLocationAsync();
            Location location = null;

            if (location == null)
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                location = await Geolocation.GetLocationAsync(request);

                if (location == null)
                {
                    throw new ApplicationException("Unable to get location");
                }
            }

            const string endpoint = "/search/2/nearbySearch/.json";
            var requestUrl =
                $"{endpoint}?lat={location.Latitude}&lon={location.Longitude}&radius=1500&idxSet=POI&categorySet={TomtomApiChurchCategory}&key={TomtomApiToken}";
            var response = await Client.GetAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var nearbySearchResult = JsonConvert.DeserializeObject<NearbySearchResult>(responseBody);

            return nearbySearchResult.Results.Select(ToChurch).ToList();
        }

        private static Church ToChurch(Result x) => new Church
        {
            Name = x.PointOfInterest.Name,
            Address = x.Address.FreeformAddress,
            MetersAway = (int) x.MetersAway,
            Latitude = x.Position.Latitude,
            Longitude = x.Position.Longitude,
        };
    }
}
