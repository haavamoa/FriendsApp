namespace FriendsApp.Services.Http
{
    public interface IHttpClientFactory
    {
        IHttpClient Create();
    }
}