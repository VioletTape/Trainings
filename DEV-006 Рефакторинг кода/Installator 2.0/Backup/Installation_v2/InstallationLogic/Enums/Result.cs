using System;

namespace Installation_v2.InstallationLogic.Enums {
    public class Result {
        public OperationResult OperationResult;
        public Exception Exception;

        public string ErrorText {
            get { return CreateErrorText(); }
        }

        private string CreateErrorText() {
            if (Exception == null) return string.Empty;

            return Exception.Message;
        }
    }
}