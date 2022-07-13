using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHANG_Thierry_TP3_ST2API.Models
{
    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
        public string pod { get; set; }
    }
}