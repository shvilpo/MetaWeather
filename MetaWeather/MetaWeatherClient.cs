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
    public class MetaWeatherClient
    {
        private readonly HttpClient _Client;
        public MetaWeatherClient(HttpClient Client) { _Client = Client; }

        private static readonly JsonSerializerOptions __JsonOptions = new()
        {
            Converters =
            {
                new JsonStringEnumConverter(),
                new JsonCoordConverter()
            }
        };

        public async Task<WeatherItem> GetWeatherByName(string loc_name, string appid, CancellationToken Cancel = default)
        {
            var req = $"weather?q={loc_name}&lang=ru&units=metric&appid={appid}";
            //var response = await _Client.GetAsync(req);
            return await _Client.GetFromJsonAsync<WeatherItem>(req, __JsonOptions, Cancel)
                .ConfigureAwait(false);
        }
        public async Task<WeatherItem> GetWeatherByCoords((double lat, double lon) coord, string appid, CancellationToken Cancel = default)
        {
            var req = $"weather?lat={coord.lat}&lon={coord.lon}&lang=ru&units=metric&appid={appid}";
            return await _Client.GetFromJsonAsync<WeatherItem>(req, __JsonOptions, Cancel)
                .ConfigureAwait(false);
        }
    }

}
