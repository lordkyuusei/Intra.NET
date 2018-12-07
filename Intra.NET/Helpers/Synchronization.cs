using Intra.NET.Constants;
using LiteDB;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intra.NET.Helpers
{
    public class Synchronization
    {
        public DateTime LastSynchronization { get; set; }

        public string UpdateIntranetData()
        {
            HttpClientWrapper httpClient = HttpClientWrapper.Instance;
            var result = httpClient.GetStringAsync(new Uri(EntAPI.intranetUri));
            LastSynchronization = DateTime.Now;
            return result.Result;
        }
        public bool SynchronizeBoardEntity<T>(LiteDatabase db, string type)
        {
            string rawData = UpdateIntranetData();
            JObject jsonData = JObject.Parse(rawData);

            var collection = db.GetCollection<T>(type);
        }
    }
}
