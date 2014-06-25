using System;
using System.Net;

namespace AsyncProgramming.Patterns {
    /// <summary>
    ///     Classic assync programming (a.k.a. APM) samples
    /// </summary>
    public class APMSample {
        private static readonly string[] urls = new[] {
            "http://codeproject.com",
            "http://stackoverflow.com",
            "http://msdn.microsoft.com"
        };

        public static void RunSample() {
            foreach (var url in urls) {
                var webRequest = WebRequest.Create(url);
                var iac = webRequest.BeginGetResponse(EndGetResponse, webRequest);
            }
        }

        private static void EndGetResponse(IAsyncResult ar) {
            var webRequest = (WebRequest) ar.AsyncState;

            try {
                var result = webRequest.EndGetResponse(ar);
            }
            catch (Exception e) {
                Console.WriteLine(e);
            }
        }
    }
}