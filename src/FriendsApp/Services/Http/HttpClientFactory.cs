namespace FriendsApp.Services.Http
{
    public class HttpClientFactory : IHttpClientFactory
    {
        private readonly IHttpClient m_httpClient;

        public HttpClientFactory(IHttpClient httpClient)
        {
            m_httpClient = httpClient;
        }
        public IHttpClient Create()
        {
            return m_httpClient;
        }
    }
}