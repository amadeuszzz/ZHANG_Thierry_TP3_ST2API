using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ZHANG_Thierry_TP3_ST2API.Models
{
    public class Api
    {
        public String key;
        public Api(string k)
        {
            key = k;
        }

        public OpenWeather getWeatherData(string city)
        {
            city.Replace(" ", "%20");
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.openweathermap.org/data/2.5/weather?q=" + city + "&APPID=" + key));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<OpenWeather>(jsonString);
        }

        public OpenForecast getForecastData(string city)
        {
            city.Replace(" ", "%20");
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("https://api.openweathermap.org/data/2.5/forecast?q=" + city + "&APPID=" + key));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<OpenForecast>(jsonString);
        }

        public OpenAirPollution getAirPollutiontData(string lon, string lat)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(string.Format("http://api.openweathermap.org/data/2.5/air_pollution?lat=" + lat + "&lon=" + lon + "&appid=" + key));
            WebReq.Method = "GET";
            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            string jsonString;
            using (Stream stream = WebResp.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream, System.Text.Encoding.UTF8);
                jsonString = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<OpenAirPollution>(jsonString);
        }

    }
}