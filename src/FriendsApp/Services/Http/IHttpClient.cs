using System;
using System.Threading.Tasks;

namespace FriendsApp.Services.Http
{
    public interface IHttpClient    
    {
        Task<string> GetAsync(Uri uri);
    }
}