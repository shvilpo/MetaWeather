using System.Text.Json;
using System.Text.Json.Serialization;

namespace MetaWeather
{
    internal class JsonCoordConverter : JsonConverter<(double Lat, double Lon)>
    {
        public override (double Lat, double Lon) Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var c = reader.GetString();
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, (double Lat, double Lon) value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }

}
