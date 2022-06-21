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

        public override string ToString()
        {
            return $"{Name}({Timezone}:{Coord.lat}:{Coord.lon}: {Weather[0].main}({Weather[0].description}), temp:{Main.temp})";
        }
    }

    public class w_main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
    }
    public class w_coord
    {
        public double lon { get; set; }
        public float lat { get; set; }
    }
    public class w_sys
    {
        public int type { get; set; }
        public int id { get; set; }
    }
    public class w_weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
