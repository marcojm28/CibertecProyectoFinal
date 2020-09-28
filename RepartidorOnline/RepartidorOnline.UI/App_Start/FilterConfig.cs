using RepartidorOnline.UI.Filters;
using System.Web;
using System.Web.Mvc;

namespace RepartidorOnline.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LogginFilterAttribute());
            filters.Add(new HandleCustomError());
        }
    }
}
