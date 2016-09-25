using System;
using System.Collections.Generic;

namespace Infrastructure {
    public class ConnectionHelper {
        private enum connect {
            WinReal,
            Test
        }


        private static connect connectMode = connect.WinReal;

        private static readonly Dictionary<string, string> testConnections
            = new Dictionary<string, string> {
                                                 {"LETHIATHAN", @"Data Source=.\lcf;Initial Catalog=Warehouse;Integrated Security=True"},
                                             };

        private static readonly Dictionary<string, string> connections
            = new Dictionary<string, string> {
                                                 {"LETHIATHAN", @"Data Source=.\lcf;Initial Catalog=Warehouse;Integrated Security=True"},
                                             };

        private static string WinConnection {
#if DEBUG
            get { return connections[Environment.MachineName]; }
#else
            get { return @":-P"; }
#endif
        }


        private static string TestConnection {
            get { return testConnections[Environment.MachineName]; }
        }

        public static string CurrentConnection {
            get {
                switch (connectMode) {
                    case connect.WinReal:
                        return WinConnection;
                    case connect.Test:
                        return TestConnection;
                }
                return "";
            }
        }


        public ConnectionHelper UseWinConnection() {
            connectMode = connect.WinReal;
            return this;
        }

        public ConnectionHelper UseTestConnection() {
            connectMode = connect.Test;
            return this;
        }
    }
}