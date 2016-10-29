using System.Web.Http;
using Owin;

namespace SyncAsyncComparison
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);

            appBuilder.Use<GlobalExceptionMiddleware>();

            appBuilder.UseWebApi(httpConfiguration);
        }
    }
}
