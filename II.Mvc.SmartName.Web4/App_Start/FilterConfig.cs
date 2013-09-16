using System.Web;
using System.Web.Mvc;

namespace II.Mvc.SmartName.Web4
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}