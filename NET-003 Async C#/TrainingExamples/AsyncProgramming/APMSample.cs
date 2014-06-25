using System;
using System.Net;

namespace AsyncProgramming {
    /// <summary>
    ///     Classic assync programming (a.k.a. APM) samples
    /// </summary>
    public class APMSample {
        private static readonly string[] _urls = new[] {
                                                           "http://rsdn.ru",
                                                           "http://gotdotnet.ru",
                                                           "http://msdn.microsoft.com"
                                                       };

        public static void RunSample() {
            foreach (var url in _urls) {
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