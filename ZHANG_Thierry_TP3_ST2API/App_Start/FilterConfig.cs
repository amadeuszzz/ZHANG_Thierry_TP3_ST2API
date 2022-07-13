using System.Web;
using System.Web.Mvc;

namespace ZHANG_Thierry_TP3_ST2API
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
