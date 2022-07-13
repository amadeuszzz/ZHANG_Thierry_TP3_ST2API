using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHANG_Thierry_TP3_ST2API.Models
{
    public class OpenAirPollution
    {
        public Coord coord { get; set; }
        public List<List> list { get; set; }
    }
}