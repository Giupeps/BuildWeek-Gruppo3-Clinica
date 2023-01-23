using System.Web;
using System.Web.Mvc;

namespace BuildWeek_Gruppo3_Clinica
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
