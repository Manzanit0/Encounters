using Newtonsoft.Json;

namespace Encounters.Pages.Locations
{
    public class NearbySearchResult
    {
        [JsonProperty("summary")]
        public Summary Summary { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }

    public class Result
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("dist")]
        public double MetersAway { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("poi")]
        public PointOfInterest PointOfInterest { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("position")]
        public GeoBias Position { get; set; }

        [JsonProperty("viewport")]
        public Viewport Viewport { get; set; }

        [JsonProperty("entryPoints")]
        public EntryPoint[] EntryPoints { get; set; }
    }

    public class Address
    {
        [JsonProperty("streetName")]
        public string StreetName { get; set; }

        [JsonProperty("municipalitySubdivision")]
        public string MunicipalitySubdivision { get; set; }

        [JsonProperty("municipality")]
        public string Municipality { get; set; }

        [JsonProperty("countrySecondarySubdivision")]
        public string CountrySecondarySubdivision { get; set; }

        [JsonProperty("countrySubdivision")]
        public string CountrySubdivision { get; set; }

        [JsonProperty("countrySubdivisionName")]
        public string CountrySubdivisionName { get; set; }

        [JsonProperty("postalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("extendedPostalCode")]
        public string ExtendedPostalCode { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("countryCodeISO3")]
        public string CountryCodeIso3 { get; set; }

        [JsonProperty("freeformAddress")]
        public string FreeformAddress { get; set; }

        [JsonProperty("localName")]
        public string LocalName { get; set; }

        [JsonProperty("streetNumber")]
        public string StreetNumber { get; set; }
    }

    public class EntryPoint
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("position")]
        public GeoBias Position { get; set; }
    }

    public class GeoBias
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }

    public class PointOfInterest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("categorySet")]
        public CategorySet[] CategorySet { get; set; }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("classifications")]
        public Classification[] Classifications { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class CategorySet
    {
        [JsonProperty("id")]
        public long Id { get; set; }
    }

    public class Classification
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("names")]
        public Name[] Names { get; set; }
    }

    public class Name
    {
        [JsonProperty("nameLocale")]
        public string NameLocale { get; set; }

        [JsonProperty("name")]
        public string NameName { get; set; }
    }

    public class Viewport
    {
        [JsonProperty("topLeftPoint")]
        public GeoBias TopLeftPoint { get; set; }

        [JsonProperty("btmRightPoint")]
        public GeoBias BtmRightPoint { get; set; }
    }

    public class Summary
    {
        [JsonProperty("queryType")]
        public string QueryType { get; set; }

        [JsonProperty("queryTime")]
        public long QueryTime { get; set; }

        [JsonProperty("numResults")]
        public long NumResults { get; set; }

        [JsonProperty("offset")]
        public long Offset { get; set; }

        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("fuzzyLevel")]
        public long FuzzyLevel { get; set; }

        [JsonProperty("geoBias")]
        public GeoBias GeoBias { get; set; }
    }
}
