using System.Web.Http;

namespace SyncAsyncComparison
{
    public class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "CustomersRoute",
                routeTemplate: "{controller}/{action}",
                defaults: new { controller = "Customers", action = "AsyncGet" }
                );
        }
    }
}
