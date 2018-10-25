using System;
using System.ComponentModel;
using Prism.Windows.Mvvm;
using Intra.NET.Constants;
using Intra.NET.Helpers;
using System.Windows.Input;
using Prism.Commands;
using Windows.ApplicationModel.Resources;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using Windows.UI.Xaml.Controls;
using Prism.Windows.Navigation;

namespace Intra.NET.ViewModels
{
    public class SignViewModel : ViewModelBase
    {
        #region Private fields & public members
        private readonly ResourceLoader resw = ResourceLoader.GetForViewIndependentUse("SignViewModelStrings");
        private readonly INavigationService navigationService;
        private readonly HttpClientWrapper  clientWrapper;
        private string introduction;
        private string userName = string.Empty;
        private Uri userPicture = new Uri(string.Format("{0}.jpg", EntAPI.UserPicturesCdc));
        private bool isLoggedOut;
        private bool isBusy;

        public string Introduction { get => introduction; set => SetProperty(ref introduction, value); }
        public bool IsLoggedOut { get => isLoggedOut; set => SetProperty(ref isLoggedOut, value); }
        public string UserName { get => userName; set => SetProperty(ref userName, value); }
        public Uri UserPicture { get => userPicture; set => SetProperty(ref userPicture, value); }
        public bool IsBusy { get => isBusy; set => SetProperty(ref isBusy, value); }

        public ICommand IntranetAuthenticateCommand;
        public ICommand IntranetInvalidateCommand;
        #endregion

        #region View Model Constructor
        /// <summary>
        /// View model constructor. We first set private properties, then public fields, and last the commands.
        /// </summary>
        /// <param name="navigation">The INavigationService service that makes navigation possible.</param>
        public SignViewModel(INavigationService navigation)
        {
            navigationService = navigation;
            clientWrapper = HttpClientWrapper.Instance;

            IsLoggedOut = clientWrapper.GetCookieFrom(new Uri(EntAPI.intranetUri)) == null;
            Introduction = IsLoggedOut ? resw.GetString("GREETINGS") : resw.GetString("GREETINGS-END");
            IntranetAuthenticateCommand = new DelegateCommand<object>(IntranetAuthenticate, CanAuthenticate).ObservesProperty(() => UserName);
            IntranetInvalidateCommand = new DelegateCommand(IntranetInvalidate);
        }
        #endregion

        #region Binded Methods
        /// <summary>
        /// The main method that authenticate the user to the EPITECH's Intranet. It goes through all the Office365 steps by querying and sending data to gain the cookie that the intranet uses.
        ///  - Step 1 : we query the login.microsoftonline.com unique url, designed for the EPITECH's intranet app, to get @flowToken and @originalRequest parameters.
        ///  - Step 2 : using the previously gathered data, we query the login.microsoftonline.com/GetCredential endpoint. It gives an answer containing the sts.epitech.eu unique url for the user's account.
        ///  - Step 3 : using the previously gathered data, we query the sts.epitech.eu endpoint with the user's login and password. It gives an answer containing 
        /// </summary>
        /// <param name="parameter">An object that contains the user's password. For safety reasons, it is not stored into public members.</param>
        public async void IntranetAuthenticate(object parameter)
        {
            HttpClientWrapper clientWrapper = HttpClientWrapper.Instance;
            PasswordBox passwordBox = parameter as PasswordBox; 
            TokenFinder tokenFinder = new TokenFinder();

            Introduction = resw.GetString("GREETINGS-CONNEXION");
            IsBusy = true;

            string webPage = await clientWrapper.GetStringAsync(new Uri(EntAPI.officeAuthUrl));
            string flowToken = tokenFinder.FetchJson(resw.GetString("REGEX-TOKEN-FLOWTOKEN"), webPage, resw.GetString("REGEX-CLEAN-DELIMS"));
            string originalRequest = tokenFinder.FetchJson(resw.GetString("REGEX-TOKEN-ORIGINALRQ"), webPage, resw.GetString("REGEX-CLEAN-DELIMS"));

            Dictionary<string, string> keyValForCredentials = new Dictionary<string, string>()
            {
                { "username", Uri.EscapeUriString(UserName) },
                { "originalRequest", originalRequest },
                { "flowToken", flowToken }
            };

            Dictionary<String, String> keyValForFederation = new Dictionary<String, String>()
            {
                { "UserName",  Uri.EscapeUriString(UserName) },
                { "Password",  passwordBox.Password },
                { "AuthMethod",  "FormsAuthentication" },
            };

            Dictionary<string, string> keyValForWRequest = new Dictionary<string, string>()
            {
                {"wa", "" },
                {"wresult", "" },
                {"wctx", "" },
            };

            webPage = await clientWrapper.PostJsonAsync(new Uri(EntAPI.getCredentials),
                JsonConvert.SerializeObject(keyValForCredentials, Formatting.Indented).ToString());
            string webResult = JObject.Parse(webPage)["Credentials"]["FederationRedirectUrl"].ToString();
            webPage = await clientWrapper.PostStringAsync(new Uri(webResult), keyValForFederation);

            webResult = tokenFinder.Fetch(resw.GetString("REGEX-TOKEN_STS-EPITECH-EU"), webPage);
            string finalUri = webResult.Substring(webResult.IndexOf("action") + "action=".Length + 1, webResult.Length - "action=".Length - 2);

            webResult = tokenFinder.Fetch(resw.GetString("REGEX-TOKEN-WA"), webPage);
            keyValForWRequest["wa"] = tokenFinder.Fetch(resw.GetString("REGEX-TOKEN-WA"), webPage).Substring(webResult.IndexOf("value") + "value=".Length + 1, webResult.Length - (webResult.IndexOf("value") + "value=".Length) - 2);

            webResult = tokenFinder.Fetch(resw.GetString("REGEX-TOKEN-WRESULT"), webPage);
            keyValForWRequest["wresult"] = System.Net.WebUtility.HtmlDecode(tokenFinder.Fetch(resw.GetString("REGEX-TOKEN-WRESULT"), webPage).Substring(webResult.IndexOf("value") + "value=".Length + 1, webResult.Length - (webResult.IndexOf("value") + "value=".Length) - 2));

            webResult = tokenFinder.Fetch(resw.GetString("REGEX-TOKEN-WCTX"), webPage);
            keyValForWRequest["wctx"] = System.Net.WebUtility.HtmlDecode(tokenFinder.Fetch(resw.GetString("REGEX-TOKEN-WCTX"), webPage).Substring(webResult.IndexOf("value") + "value=".Length + 1, webResult.Length - (webResult.IndexOf("value") + "value=".Length) - 2));

            webPage = await clientWrapper.PostStringAsync(new Uri(finalUri), keyValForWRequest);
            webPage = await clientWrapper.GetStringAsync(new Uri(EntAPI.officeAuthUrl));

            //string sessionId = tokenFinder.FetchJson(resw.GetString("REGEX-TOKEN-SESSIONID"), webPage, resw.GetString("REGEX-CLEAN-DELIMS"));
            //string canary = tokenFinder.FetchJson(resw.GetString("REGEX-TOKEN-CANARY"), webPage, resw.GetString("REGEX-CLEAN-DELIMS"));
            //webResult = await clientWrapper.PostStringAsync(new Uri(EntAPI.officeKmsi), new Dictionary<string, string>()
            //{
            //    { "LoginOptions", "1" },
            //    { "ctx", originalRequest},
            //    { "flowToken", flowToken },
            //    { "hpgrequestid", sessionId },
            //    { "canary", canary },
            //    { "i19", "4746" }
            //});

            IsBusy = false;
            navigationService.Navigate("Dash", null);
        }

        private bool CanAuthenticate(object arg)
        {
            return new TokenFinder().Fetch(resw.GetString("REGEX-USERNAME"), UserName) != null;
        }

        /// <summary>
        /// A method that disconnect the user by sending a POST request to the EPITECH's intranet for rights revocating, then by deleting local cookies.
        /// </summary>
        public async void IntranetInvalidate()
        {
            string webPage = await clientWrapper.PostStringAsync(new Uri(EntAPI.intranetLogoutUri), null);
            clientWrapper.RemoveCookiesFrom(new Uri(EntAPI.intranetUri));
            Introduction = resw.GetString("GREETINGS");
            IsLoggedOut = true;
        }
        #endregion

        /// <summary>
        /// This method is triggered when a field that subscribed to PropertyChanged event (with the SetProperty method) is modified.
        /// </summary>
        /// <param name="e">The property details. Check e.name for the property name.</param>
        protected override async void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (e.PropertyName == "UserName" && !string.IsNullOrEmpty(UserName))
            {
                var url = new Uri(String.Format("{0}{1}.jpg", EntAPI.UserPicturesCdc, UserName.Split('@')[0]));
                var output = await clientWrapper.GetStringAsync(url);
                if (clientWrapper.IsLastStatusCode(Windows.Web.Http.HttpStatusCode.Ok))
                {
                    UserPicture = url;
                    Introduction = resw.GetString("GREETINGS-RECOGNIZE");
                }
            }
        }
    }
}
