﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetaWeather.Models
{

    public class WorldWeatherItem
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public Request[] request { get; set; }
        public Weather[] weather { get; set; }
        public Climateaverage[] ClimateAverages { get; set; }
    }

    public class Request
    {
        public string type { get; set; }
        public string query { get; set; }
    }

    public class Weather
    {
        public string date { get; set; }
        public Astronomy[] astronomy { get; set; }
        public string maxtempC { get; set; }
        public string maxtempF { get; set; }
        public string mintempC { get; set; }
        public string mintempF { get; set; }
        public string avgtempC { get; set; }
        public string avgtempF { get; set; }
        public string totalSnow_cm { get; set; }
        public string sunHour { get; set; }
        public string uvIndex { get; set; }
        public Hourly[] hourly { get; set; }
    }

    public class Astronomy
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string moonrise { get; set; }
        public string moonset { get; set; }
        public string moon_phase { get; set; }
        public string moon_illumination { get; set; }
    }

    public class Hourly
    {
        public string time { get; set; }
        public string tempC { get; set; }
        public string tempF { get; set; }
        public string windspeedMiles { get; set; }
        public string windspeedKmph { get; set; }
        public string winddirDegree { get; set; }
        public string winddir16Point { get; set; }
        public string weatherCode { get; set; }
        public Weathericonurl[] weatherIconUrl { get; set; }
        public Weatherdesc[] weatherDesc { get; set; }
        public Lang_Ru[] lang_ru { get; set; }
        public string precipMM { get; set; }
        public string precipInches { get; set; }
        public string humidity { get; set; }
        public string visibility { get; set; }
        public string visibilityMiles { get; set; }
        public string pressure { get; set; }
        public string pressureInches { get; set; }
        public string cloudcover { get; set; }
        public string HeatIndexC { get; set; }
        public string HeatIndexF { get; set; }
        public string DewPointC { get; set; }
        public string DewPointF { get; set; }
        public string WindChillC { get; set; }
        public string WindChillF { get; set; }
        public string WindGustMiles { get; set; }
        public string WindGustKmph { get; set; }
        public string FeelsLikeC { get; set; }
        public string FeelsLikeF { get; set; }
        public string chanceofrain { get; set; }
        public string chanceofremdry { get; set; }
        public string chanceofwindy { get; set; }
        public string chanceofovercast { get; set; }
        public string chanceofsunshine { get; set; }
        public string chanceoffrost { get; set; }
        public string chanceofhightemp { get; set; }
        public string chanceoffog { get; set; }
        public string chanceofsnow { get; set; }
        public string chanceofthunder { get; set; }
        public string uvIndex { get; set; }
    }

    public class Weathericonurl
    {
        public string value { get; set; }
    }

    public class Weatherdesc
    {
        public string value { get; set; }
    }

    public class Lang_Ru
    {
        public string value { get; set; }
    }

    public class Climateaverage
    {
        public Month[] month { get; set; }
    }

    public class Month
    {
        public string index { get; set; }
        public string name { get; set; }
        public string avgMinTemp { get; set; }
        public string avgMinTemp_F { get; set; }
        public string absMaxTemp { get; set; }
        public string absMaxTemp_F { get; set; }
        public string avgDailyRainfall { get; set; }
    }

}
