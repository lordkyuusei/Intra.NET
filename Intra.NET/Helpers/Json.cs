using System;
using System.IO;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Intra.NET.Helpers
{
    public static class Json
    {
        public static async Task<T> ToObjectAsync<T>(string value)
        {
            return await Task.Run<T>(() =>
            {
                return JsonConvert.DeserializeObject<T>(value);
            });
        }

        public static async Task<string> StringifyAsync(object value)
        {
            return await Task.Run<string>(() =>
            {
                return JsonConvert.SerializeObject(value);
            });
        }

        public static T Deserialize<T>(string json)
        {
            JsonSerializer serializer = new JsonSerializer();
            return serializer.Deserialize<T>(new JsonTextReader(new StringReader(json)));
        }

        public static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
