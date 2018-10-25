using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace Intra.NET.Helpers
{
    class HttpClientWrapper
    {
        private HttpClient httpClient;
        private HttpResponseMessage httpResponse;
        private HttpBaseProtocolFilter httpFilter;
        private string htmlResponse;

        private static HttpClientWrapper instance;

        private HttpClientWrapper()
        {
            httpFilter = new HttpBaseProtocolFilter();
            httpFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            httpClient = new HttpClient(httpFilter);
        }

        public static HttpClientWrapper Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HttpClientWrapper();
                }
                return instance;
            }
        }

        public async Task<String> GetStringAsync(Uri uri)
        {
            try
            {
                if (uri != null)
                {
                    return await GetAsync(uri);
                }
                else
                {
                    htmlResponse = null;
                    throw new ArgumentNullException("The URI cannot be empty");
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<string> PostJsonAsync(Uri uri, string jsonQuery)
        {
            try
            {
                if (uri != null && jsonQuery != null)
                {
                    return await this.PostJsonAsync2(uri, new HttpStringContent(jsonQuery, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
                }
                else
                {
                    this.htmlResponse = null;
                    throw new ArgumentException("The URI and the QUERY cannot be empty");
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public async Task<string> PostStringAsync(Uri uri, Dictionary<string, string> query)
        {
            try
            {
                if (uri != null && query != null)
                {
                    return await this.PostAsync(uri, new HttpFormUrlEncodedContent(query));
                }
                else
                {
                    this.htmlResponse = null;
                    throw new ArgumentException("The URI and the QUERY cannot be empty");
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        private async Task<string> GetAsync(Uri uri)
        {
            httpResponse = await httpClient.GetAsync(uri);
            htmlResponse = await httpResponse.Content.ReadAsStringAsync();
            return htmlResponse;
        }
        private async Task<string> PostAsync(Uri uri, HttpFormUrlEncodedContent content)
        {
            httpResponse = await httpClient.PostAsync(uri, content);
            htmlResponse = await httpResponse.Content.ReadAsStringAsync();
            return htmlResponse;
        }
        private async Task<string> PostJsonAsync2(Uri uri, HttpStringContent content)
        {
            httpResponse = await httpClient.PostAsync(uri, content);
            htmlResponse = await httpResponse.Content.ReadAsStringAsync();
            return htmlResponse;
        }

        public string GetCookieFrom(Uri uri)
        {
            string ret = null;
            foreach (var cookie in httpFilter.CookieManager.GetCookies(uri))
            {
                ret += cookie.Name + "=" + cookie.Value + "; ";
            }
            return ret;
        }

        public void RemoveCookiesFrom(Uri uri)
        {
            foreach (var cookie in httpFilter.CookieManager.GetCookies(uri))
            {
                httpFilter.CookieManager.DeleteCookie(cookie);
            }
        }

        public bool IsLastStatusCode(HttpStatusCode httpStatusCode)
        {
            return httpResponse.StatusCode == httpStatusCode;
        }
    }
}
