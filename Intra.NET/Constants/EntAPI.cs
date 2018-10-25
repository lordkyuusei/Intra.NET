using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intra.NET.Constants
{
    internal static class EntAPI
    {
        public const string UserPicturesCdc = "https://cdn.local.epitech.eu/userprofil/profilview/";
        public const string intranetUri = "https://intra.epitech.eu/?format=json";
        public const string intranetLogoutUri = "https://intra.epitech.eu/logout?format=json";
        public const string getCredentials = "https://login.microsoftonline.com/common/GetCredentialType?mkt=fr-FR";
        public const string officeAuthUrl = "https://login.microsoftonline.com/common/oauth2/authorize?response_type=code&client_id=e05d4149-1624-4627-a5ba-7472a39e43ab&redirect_uri=https%3A%2F%2Fintra.epitech.eu%2Fauth%2Foffice365&state=%2F%3Fformat%3Djson";
        public const string officeKmsi = "https://login.microsoftonline.com/kmsi";
    }
}
