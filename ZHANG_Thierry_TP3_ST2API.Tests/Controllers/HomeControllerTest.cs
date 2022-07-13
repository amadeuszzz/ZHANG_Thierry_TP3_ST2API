using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ZHANG_Thierry_TP3_ST2API;
using ZHANG_Thierry_TP3_ST2API.Controllers;
using ZHANG_Thierry_TP3_ST2API.Models;

namespace ZHANG_Thierry_TP3_ST2API.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            HomeController controller = new HomeController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void LoadWeather()
        {
            Api api = new Api("8cbae7f191881e287c2b9e381ff5d923");
            String city = "London";
            OpenWeather res = api.getWeatherData(city);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.name, city);
            Assert.IsInstanceOfType(res.coord.lon, typeof(double));
            Assert.IsInstanceOfType(res.coord.lat, typeof(double));
            Assert.IsTrue(res.coord.lon < 180 && res.coord.lon > -180);
            Assert.IsTrue(res.coord.lat < 180 && res.coord.lat > -180);
        }

        [TestMethod]
        public void LoadForecast()
        {
            Api api = new Api("8cbae7f191881e287c2b9e381ff5d923");
            String city = "London";
            OpenForecast res = api.getForecastData(city);
            Assert.IsNotNull(res);
            Assert.AreEqual(res.city.name, city);
            Assert.IsInstanceOfType(res.cnt, typeof(int));
            Assert.IsTrue(res.list.Count == res.cnt);
        }

        [TestMethod]
        public void LoadAirPollution()
        {
            Api api = new Api("8cbae7f191881e287c2b9e381ff5d923");
            String longitude = "-0.1257";
            String latitude = "51.5085";
            OpenAirPollution res = api.getAirPollutiontData(longitude, latitude);
            Assert.IsNotNull(res);
            Assert.IsInstanceOfType(res.list[0].main.aqi, typeof(int));
        }
    }
}
