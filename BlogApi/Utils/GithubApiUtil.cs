using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlogApi.Utils
{
    public class GithubApiUtil
    {
        public static async Task<T> GetDataOrElse<T>(string apiUrl, Func<T> orElse)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders
                    .UserAgent
                    .TryParseAdd("C# HttpClient");
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return orElse();
                }
            }
        }
    }
}
