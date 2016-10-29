using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using SyncAsyncComparison.Model;

namespace SyncAsyncComparison.Controllers
{
    [RoutePrefix("Customers")]
    public class CustomersController : ApiController
    {
        [HttpGet]
        public async Task<IHttpActionResult> AsyncGet200MsDelay()
        {
            // simulate a delay - could be a database query or another service request
            await Task.Delay(200);
            
            return await Task.FromResult(Ok(GetSampleCustomers()));
        }
        
        [HttpGet]
        public IHttpActionResult SyncGet200MsDelay()
        {
            // simulate a delay - could be a database query or another service reque
            Task.Delay(200).Wait();
            
            return Ok(GetSampleCustomers());
        }

        [HttpGet]
        public async Task<IHttpActionResult> AsyncGetCpuBound()
        {
            var result = HeavyWork();

            return await Task.FromResult(Ok(result));
        }

        [HttpGet]
        public IHttpActionResult SyncGetCpuBound()
        {
            var result = HeavyWork();

            return Ok(result);
        }
        
        private static long HeavyWork()
        {
            return SpendSomeTime(1000000);
        }

        private static long SpendSomeTime(int upperBound)
        {
            var sum = 0L;
            var rand = new Random();

            for (var i = 0; i < upperBound; ++i)
            {
                sum += i * rand.Next(0, 5);
            }

            return sum;
        }

        private static IList<Customer> GetSampleCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer() {Name = "Nice customer", Address = "USA", Telephone = "123345456"},
                new Customer() {Name = "Good customer", Address = "UK", Telephone = "9878757654"},
                new Customer() {Name = "Awesome customer", Address = "France", Telephone = "34546456"},
                new Customer() {Name = "This is Synchronous", Address = "Turkey", Telephone = "12345678"}
            };

            return customers;
        }
    }
}
