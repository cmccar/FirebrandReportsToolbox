using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Oauth2;
using Google.Apis.Util;
using Google.GData.Client;
using Google.GData.Spreadsheets;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.Diagnostics;

namespace FirebrandReportsToolbox
{
    public static class GoogleApiDriver
    {
        private static SpreadsheetsService masterSpreadsheetService;
        public static SpreadsheetsService MasterSpreadsheetService { get { return masterSpreadsheetService; } }

        public static void ConfigureOAuth2(bool _changeAuth)
        {
            // OAuth 2.0 Client ID and Secrets
            string CLIENT_ID = "3730216929-nauhdvj3mn35p8mjnon14qihhf0idqpe.apps.googleusercontent.com";
            string CLIENT_SECRET = "tetDDxB8j0KLTrdGPqjR1ip6";

            // Space separated list of scopes for which to request access.
            string SCOPE = "https://spreadsheets.google.com/feeds https://docs.google.com/feeds";

            // Redirect to localhost, listener should catch authorization response
            string REDIRECT_URI = string.Format("http://{0}:{1}/", IPAddress.Loopback, Utility.GetRandomUnusedPort());

            // OAuth2Parameters holds all the parameters related to OAuth 2.0.
            OAuth2Parameters parameters = new OAuth2Parameters();
            parameters.ClientId = CLIENT_ID;
            parameters.ClientSecret = CLIENT_SECRET;
            parameters.RedirectUri = REDIRECT_URI;
            parameters.Scope = SCOPE;

            GOAuth2RequestFactory requestFactory = null;
            string refreshToken = LoadRefreshToken();
            if(!string.IsNullOrEmpty(refreshToken) && !_changeAuth)
            {
                parameters.AccessToken = refreshToken;
                parameters.RefreshToken = refreshToken;
                // Initialize the variables needed to make the request with refresh token
                requestFactory =
                    new GOAuth2RequestFactory(null, "Firebrand Reports Toolbox", parameters);
                masterSpreadsheetService = new SpreadsheetsService("Firebrand Reports Toolbox");
                masterSpreadsheetService.RequestFactory = requestFactory;
                return;
            }

            // Get the authorization url.  Must visit this url in order to authorize app with Google.
            string authorizationUrl = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);

            // Prompt user to enter the access code
            using (var enterAccessCodeForm = new GetAccessCodeForm(REDIRECT_URI, authorizationUrl))
            {
                var result = enterAccessCodeForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    parameters.AccessCode = enterAccessCodeForm.AuthorizationCode;           
                }
            }

            // Once the user authorizes with Google, the request token can be exchanged
            // for a long-lived access token.  If you are building a browser-based
            // application, you should parse the incoming request token from the url and
            // set it in OAuthParameters before calling GetAccessToken().
            OAuthUtil.GetAccessToken(parameters);
            string accessToken = parameters.AccessToken;
            SaveRefreshToken(parameters.RefreshToken);

            // Initialize the variables needed to make the request now that OAuth2 is done
            requestFactory =
                new GOAuth2RequestFactory(null, "Firebrand Reports Toolbox", parameters);
            masterSpreadsheetService = new SpreadsheetsService("Firebrand Reports Toolbox");
            masterSpreadsheetService.RequestFactory = requestFactory;
        }

        private static string LoadRefreshToken()
        {
            // TO DO: FIX ENCRYPTION - return Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(Properties.Settings.Default.RefreshToken), additionalEntropy, DataProtectionScope.CurrentUser));
            return Encoding.Unicode.GetString(Convert.FromBase64String(Properties.Settings.Default.RefreshToken));
        }

        private static void SaveRefreshToken(string _refreshToken)
        {
            // TO DO: FIX ENCRYPTION - Properties.Settings.Default.RefreshToken = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(_refreshToken), additionalEntropy, DataProtectionScope.CurrentUser));
            Properties.Settings.Default.RefreshToken = Convert.ToBase64String(Encoding.Unicode.GetBytes(_refreshToken));
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Enter 0 for a min / max parameter to ignore the parameter
        /// </summary>
        /// <param name="_worksheetEntry">Worksheet entry to retrieve cell feed from</param>
        /// <param name="_minRow">Minimum row in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <param name="_maxRow">Maximum row in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <param name="_minCol">Minimum column in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <param name="_maxCol">Maximum column in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <returns>Retrieved cell feed if successful, otherwise returns null</returns>
        public static CellFeed GetCellFeed(WorksheetEntry _worksheetEntry, uint _minRow, uint _maxRow, uint _minCol, uint _maxCol)
        {
            try
            {
                CellQuery cellQuery = new CellQuery(_worksheetEntry.CellFeedLink);
                if(_minRow != 0) cellQuery.MinimumRow = _minRow;
                if (_maxRow != 0) cellQuery.MaximumRow = _maxRow;
                if (_minCol != 0) cellQuery.MinimumColumn = _minCol;
                if (_maxCol != 0) cellQuery.MaximumColumn = _maxCol;
                cellQuery.ReturnEmpty = ReturnEmptyCells.yes;
                CellFeed cellFeed = MasterSpreadsheetService.Query(cellQuery);
                return cellFeed;
            }
            catch(Exception ex)
            {
                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error, "Error retrieving cell feed from Google worksheet entry: " + ex.Message);
                return null;
            }
        }
    }
}
