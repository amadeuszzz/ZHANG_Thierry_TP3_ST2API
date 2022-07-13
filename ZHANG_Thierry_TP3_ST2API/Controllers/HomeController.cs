using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZHANG_Thierry_TP3_ST2API.Models;

namespace ZHANG_Thierry_TP3_ST2API.Controllers
{
    public class HomeController : Controller
    {
        static Api api = new Api("8cbae7f191881e287c2b9e381ff5d923");
        public ActionResult Index()
        {
            List<String> cities = new List<string> { "London", "New York", "Paris", "Singapore", "Tokyo", "Hong Kong", "Dubai", "Beijing", "Sydney" };
            ViewBag.Cities = cities;
            return View();
        }

        public JsonResult LoadWeather(string city)
        {
            OpenWeather res = api.getWeatherData(city);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadForecast(string city)
        {
            OpenForecast res = api.getForecastData(city);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadAirPollution(string lon, string lat)
        {
            OpenAirPollution res = api.getAirPollutiontData(lon, lat);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}