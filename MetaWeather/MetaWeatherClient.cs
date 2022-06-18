using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MetaWeather
{
    public class MetaWeatherClient
    {
        private readonly HttpClient _Client;
        public MetaWeatherClient(HttpClient Client) { _Client = Client; }
        public async Task<WeatherItem> GetWeather(string loc_name, string appid)
        {
            var req = $"weather?q={loc_name}&lang=ru&units=metric&appid={appid}";
            //var response = await _Client.GetAsync(req);
            return await _Client.GetFromJsonAsync<WeatherItem>(req);
        }
    }
    public class WeatherItem
    {
        [JsonPropertyName("coord")]
        public w_coord coord { get; set; }
        public w_weather[] weather { get; set; }
        public int visibility { get; set; }
        
        [JsonPropertyName("base")]
        public string _base { get; set; }
        public w_main main { get; set; }
        public w_sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }

    }
        
    public class w_coord
    {
        public double lon { get; set; }
        public float lat { get; set; }
    }
    public class w_weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    public class w_main
    { 
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
    }
    public class w_sys
    { 
        public int type { get; set; }
        public int id { get; set; }
    }
   
}
/*

   "main": {
       "temp": 19.85,
       "feels_like": 19.07,
       "temp_min": 19.14,
       "temp_max": 20.35,
       "pressure": 1013,
       "humidity": 45,
       "sea_level": 1013,
       "grnd_level": 996
   },
   "visibility": 10000,
   "wind": {
       "speed": 3.81,
       "deg": 296,
       "gust": 6.91
   },
   "clouds": {
       "all": 100
   },
   "dt": 1655563652,
   "sys": {
       "type": 2,
       "id": 47754,
       "country": "RU",
       "sunrise": 1655513057,
       "sunset": 1655576218
   },
   "timezone": 10800,
   "id": 524901,
   "name": "Москва",
   "cod": 200
 */