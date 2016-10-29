using System;
using System.Threading.Tasks;
using Microsoft.Owin;

namespace SyncAsyncComparison
{
    public class GlobalExceptionMiddleware : OwinMiddleware
    {
        public GlobalExceptionMiddleware(OwinMiddleware next) : base(next)
        { }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                await Next.Invoke(context);
            }
            catch (Exception ex)
            {
                // TODO: gseng - better handling?
                Console.WriteLine(ex);
            }
        }
    }
}
