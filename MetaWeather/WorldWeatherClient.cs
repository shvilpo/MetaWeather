using MetaWeather.Models;
using MetaWeather.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MetaWeather
{
    public class WorldWeatherClient
    {
        private readonly HttpClient _Client;
        public WorldWeatherClient(HttpClient Client) { _Client = Client; }
        private static readonly JsonSerializerOptions __JsonOptions = new();


        public async Task<WorldWeatherItem> GetWeatherByNameToday(string loc_name, string key, CancellationToken Cancel = default)
        {
            var req = $"weather.ashx?q={loc_name}&date_format=iso8601&date=today&format=json&lang=ru&cc=no&key={key}";
            return await _Client.GetFromJsonAsync<WorldWeatherItem>(req, __JsonOptions, Cancel)
                .ConfigureAwait(false);
        }
        public async Task<WorldWeatherItem> GetWeatherByNameDate(string loc_name, DateTime dt, string key, CancellationToken Cancel = default)
        {
            string stDt = $"{dt:yyyy}-{dt:MM}-{dt:dd}";
            var req = $"weather.ashx?q={loc_name}&date_format=iso8601&date={stDt}&format=json&lang=ru&cc=no&key={key}";
            return await _Client.GetFromJsonAsync<WorldWeatherItem>(req, __JsonOptions, Cancel)
                .ConfigureAwait(false);
        }
    }

}
