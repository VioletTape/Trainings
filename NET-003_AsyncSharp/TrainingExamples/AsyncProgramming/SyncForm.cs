using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace AsyncProgramming {
    public partial class SyncForm : Form {
        private readonly List<string> urls = new List<string> {
            "http://codeproject.com",
            "http://stackoverflow.com",
            "http://msdn.microsoft.com"
        };

        private Button button1;
        private Button button2;

        private long summaryContentLength;

        public SyncForm() {
            InitializeComponent();
        }


        private void ReceiveDataButtonClick(object sender, EventArgs e) {
            try {
                var sw = Stopwatch.StartNew();
                summaryContentLength = 0;
                foreach (var url in urls) {
                    var webRequest = WebRequest.Create(url);
                    using (var webResponse = webRequest.GetResponse()) {
                        summaryContentLength += webResponse.ContentLength;

                        summaryContentLengthTextBox.Text = summaryContentLength.ToString();
                        executionTimeTextBox.Text = sw.ElapsedMilliseconds.ToString();
                    }
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.ToString(), "Error");
            }
            finally {
                receiveDataButton.Enabled = true;
            }
        }

        private async void ButtonAsyncClick(object sender, EventArgs e) {
            try {
                receiveDataButton.Enabled = false;

                var sw = Stopwatch.StartNew();
                summaryContentLength = 0;
                foreach (var url in urls) {
                    var webRequest = WebRequest.Create(url);
                    using (var webResponse = await webRequest.GetResponseAsync()) {
                        summaryContentLength += webResponse.ContentLength;

                        summaryContentLengthTextBox.Text = summaryContentLength.ToString();
                        executionTimeTextBox.Text = sw.ElapsedMilliseconds.ToString();
                    }
                }
            }
            catch (Exception exception) {
                MessageBox.Show(exception.ToString(), "Error");
            }
            finally {
                receiveDataButton.Enabled = true;
            }
        }


        private async void ThrowExceptionAsync() {
            throw new InvalidOperationException();
        }

        public void AsyncVoidExceptions_CannotBeCaughtByCatch() {
            try {
                ThrowExceptionAsync();
            }
            catch (Exception) {
                // The exception is never caught here!
                throw;
            }
        }
    }
}