using System;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace SyncAsyncComparison
{
    static class Program
    {
        static void Main()
        {
            var ipAddr = ConfigurationManager.AppSettings["IPAddr"];
            var listeningPort = ConfigurationManager.AppSettings["ListeningPort"];

            var tsk = new Task(() =>
            {
                while (true)
                {
                    var threadNum = Process.GetCurrentProcess().Threads.Count;
                    int workerThreads;
                    int portThreads;

                    ThreadPool.GetAvailableThreads(out workerThreads, out portThreads);

                    Console.WriteLine($"At {DateTime.Now} - # of threads in use is {threadNum}, " +
                                      $"avail worker: {workerThreads}, ports: {portThreads}");

                    Thread.Sleep(1000);
                }
            }, TaskCreationOptions.LongRunning);

            tsk.Start();

            using (WebApp.Start<Startup>(ipAddr + ":" + listeningPort))
            {
                Console.WriteLine("Web Server is running.");
                Console.WriteLine("Press ctrl+c to quit.");

                new ManualResetEvent(false).WaitOne();
            }
        }
    }
}
