using System.Net;

namespace AsyncProgramming.Patterns {
    /// <summary>
    /// Classic strict sequential programm flow 
    /// </summary>
    public class SyncronousSample {
        private static readonly string[] urls = new[] {
            "http://codeproject.com",
            "http://stackoverflow.com",
            "http://msdn.microsoft.com"
        };

        public static void RunSample() {
            foreach (var url in urls) {
                var webRequest = WebRequest.Create(url);
                var iac = webRequest.GetResponse();
            }
        }
    }
}