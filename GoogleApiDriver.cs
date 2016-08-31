using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography;
using System.Diagnostics;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Sheets.v4;
using Google.Apis.Sheets.v4.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.GData.Client;
using Google.GData.Spreadsheets;

namespace FirebrandReportsToolbox
{
    public static class GoogleApiDriver
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/sheets.googleapis.com-dotnet-quickstart.json
        static string[] Scopes = { SheetsService.Scope.SpreadsheetsReadonly };
        static string ApplicationName = "Firebrand Reports Toolbox";

        private static SheetsService masterSpreadsheetService;
        public static SheetsService MasterSpreadsheetService { get { return masterSpreadsheetService; } }

        public static void Configure()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
            {
                string credPath = Environment.GetFolderPath(
                    Environment.SpecialFolder.Personal);
                credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-firebrand-reports-toolbox.json");

                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Google Sheets API service.
            masterSpreadsheetService = new SheetsService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });
        }

        private const string spreadsheetId = "18q3sAEUCIzZvrrIdGprEQgioqt1eEERoPUkjaPDB02E";
        /// <summary>
        /// Enter 0 for a min / max parameter to ignore the parameter
        /// </summary>
        /// <param name="_worksheetEntry">Worksheet entry to retrieve cell feed from</param>
        /// <param name="_minRow">Minimum row in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <param name="_maxRow">Maximum row in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <param name="_minCol">Minimum column in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <param name="_maxCol">Maximum column in worksheet to retrieve from, enter 0 to ignore parameter</param>
        /// <returns>Retrieved cell feed if successful, otherwise returns null</returns>
        public static IList<ValueRange> GetSheetValueRange(string _range, uint _minRow, uint _maxRow, uint _minCol, uint _maxCol)
        {

            try
            {
                SpreadsheetsResource.ValuesResource.BatchGetRequest request =
                        masterSpreadsheetService.Spreadsheets.Values.BatchGet(spreadsheetId);

                List<string> ranges = new List<string>();
                request.Ranges = new Google.Apis.Util.Repeatable<string>(ranges);
                BatchGetValuesResponse response = request.Execute();
                IList<ValueRange> values = response.ValueRanges;

            }
            catch (Exception ex)
            {
                FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error, "Error retrieving values from Google worksheet entry: " + ex.Message);
                return null;

            }

            return null;
        }

        public static IList<IList<object>> GetSheetValues(string _range)
        {
            try
            {
                SpreadsheetsResource.ValuesResource.GetRequest request =
                    masterSpreadsheetService.Spreadsheets.Values.Get(spreadsheetId, _range);
                ValueRange response = request.Execute();
                IList<IList<object>> values = response.Values;

                return values;
            }
            catch(Exception ex)
            {
                throw (ex);
                //FirebrandReportsToolboxForm.GRef.NewEvent(EventType.Error, "Error getting spreadsheet values: " + ex.Message);
            }
        }
        /*
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
        */
    }
}
