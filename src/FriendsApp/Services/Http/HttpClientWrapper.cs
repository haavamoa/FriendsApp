using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FriendsApp.Services.Http
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient m_actualHttpClient;

        public HttpClientWrapper()
        {
            m_actualHttpClient = new HttpClient();
        }

        public async Task<string> GetAsync(Uri uri)
        {
            var response = await m_actualHttpClient.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }

            throw new Exception("Something went wrong when running GetAsync");
        }
    }
}