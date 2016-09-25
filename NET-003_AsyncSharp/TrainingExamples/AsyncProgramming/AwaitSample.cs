using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgramming {
    public class AwaitSample {
        private static readonly List<string> urls = new List<string> {
            "http://codeproject.com",
            "http://stackoverflow.com",
            "http://msdn.microsoft.com"
        };


        public static void RunSample() {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Start. Thread Id: {0}",
                              Thread.CurrentThread.ManagedThreadId);

            //var task = GetWebResponseContentLength("http://rsdn.ru");
            var task = GetSummPageSize();
            // awaiting async operation
            task.Wait();
            Console.WriteLine("Execution time: {0}", sw.ElapsedMilliseconds);
            Console.WriteLine("ContentLength: {0}, Thread Id: {1}",
                              task.Result, Thread.CurrentThread.ManagedThreadId);

            Console.ReadLine();
        }

        private static async Task<long> GetWebResponseContentLength(string url) {
            var webRequest = WebRequest.Create(url);
            Console.WriteLine("before await-a. Thread Id: {0}",
                              Thread.CurrentThread.ManagedThreadId);

            // start async
            var responseTask = webRequest.GetResponseAsync();

            // await response 
            var webResponse = await responseTask;

            Console.WriteLine("after completing await-а. Thread Id: {0}",
                              Thread.CurrentThread.ManagedThreadId);


            return webResponse.ContentLength;
        }

        private static async Task<long> GetSummPageSize() {
            var tasks = from url in urls
                        let webRequest = WebRequest.Create(url)
                        select webRequest.GetResponseAsync();
            Console.WriteLine("Before await. Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
            try {
                var data = await Task.WhenAll(tasks);

                Console.WriteLine("After await. Thread Id: {0}", Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("data typeof: {0}", data.GetType());
                return data.Sum(s => s.ContentLength);
            }
            catch (WebException we) {
                Console.WriteLine(we);
                return 0;
            }
        }
    }
}