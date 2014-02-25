using System.Web;
using System.Web.Mvc;

namespace APS.Mvc.SmartName.Web4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}