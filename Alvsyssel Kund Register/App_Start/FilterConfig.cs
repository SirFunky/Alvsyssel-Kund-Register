using System.Web;
using System.Web.Mvc;

namespace Alvsyssel_Kund_Register
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
