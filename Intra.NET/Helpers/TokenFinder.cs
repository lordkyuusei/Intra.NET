using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Intra.NET.Helpers
{
    class TokenFinder
    {
        private Regex regex;
        private Match match;

        public string Fetch(string niddle, string haystack)
        {

            try
            {
                if (string.IsNullOrEmpty(niddle) || string.IsNullOrEmpty(haystack))
                {
                    Debug.WriteLine(niddle + " " + haystack);
                    throw new ArgumentNullException("Neither niddle or haystack can be null.");
                }
                regex = new Regex(niddle);
                match = regex.Match(haystack);

                return !match.Success ? null : match.Value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }

        public string FetchJson(string niddle, string haystack, string delims)
        {
            string json = Fetch(niddle, haystack);
            json = Fetch(delims, json.Split(":", 2, StringSplitOptions.None)[1]);
            return json.Replace("\"", "");
        }
    }
}
