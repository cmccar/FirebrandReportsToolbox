using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FirebrandReportsToolbox
{
    public partial class GetAccessCodeForm : Form
    {
        public string AuthorizationCode { get; set; }
        
        public GetAccessCodeForm(string _redirectUri, string _authorizationUrl)
        {
            InitializeComponent();
            StartLocalListening(_redirectUri);
            authorizationUrlTextBox.Text = _authorizationUrl;
        }

        private void StartLocalListening(string _redirectUri)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            Task.Factory.StartNew(() =>
            {
                // Creates an HttpListener to listen for requests on that redirect URI.
                var http = new HttpListener();
                http.Prefixes.Add(_redirectUri);
                http.Start();
                // Waits for the OAuth authorization response.
                var context = http.GetContext();

                // Sends an HTTP response to the browser.
                var response = context.Response;
                string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");
                var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                var responseOutput = response.OutputStream;
                Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
                {
                    responseOutput.Close();
                    http.Stop();
                    Console.WriteLine("HTTP server stopped.");
                });

                // Checks for errors.
                if (context.Request.QueryString.Get("error") != null)
                {
                    MessageBox.Show(String.Format("OAuth authorization error: {0}.", context.Request.QueryString.Get("error")));
                    return;
                }
                if (context.Request.QueryString.Get("code") == null)
                {
                    MessageBox.Show("Malformed authorization response. " + context.Request.QueryString);
                    return;
                }

                // extracts the code
                var code = context.Request.QueryString.Get("code");

                AuthorizationCode = code;
                CloseForm();
            }, token);
        }

        private void CloseForm()
        {
            BeginInvoke((MethodInvoker)delegate
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            });
        }
    }
}
