using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHANG_Thierry_TP3_ST2API.Models
{
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        public double temp_kf { get; set; }
        public int aqi { get; set; }
    }
}