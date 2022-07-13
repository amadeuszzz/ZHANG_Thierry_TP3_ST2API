using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHANG_Thierry_TP3_ST2API.Models
{
    public class OpenForecast
    {
        public string cod { get; set; }
        public int message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
        public City city { get; set; }
    }
}