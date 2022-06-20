using System.Text.Json.Serialization;

namespace MetaWeather.Models
{
    public class WeatherItem
    {
        [JsonPropertyName("coord")]
        public w_coord Coord { get; set; }

        [JsonPropertyName("weather")]
        public w_weather[] Weather { get; set; }
        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("base")]
        public string Base { get; set; }

        [JsonPropertyName("main")]
        public w_main Main { get; set; }

        [JsonPropertyName("sys")]
        public w_sys Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }

    }

}
