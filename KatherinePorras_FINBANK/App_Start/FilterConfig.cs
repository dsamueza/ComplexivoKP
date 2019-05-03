using System.Web;
using System.Web.Mvc;

namespace KatherinePorras_FINBANK
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
