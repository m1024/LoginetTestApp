using System.Net.Http;
using System.Threading.Tasks;

namespace Data
{
    internal static class RemoteJsonLoader
    {
        public static async Task<string> Load(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        return await content.ReadAsStringAsync();
                    }
                }
            }
        }
    }
}
