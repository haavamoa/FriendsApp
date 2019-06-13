using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FriendsApp.ViewModels;

namespace FriendsApp.Services
{
    public class FriendService : IFriendService
    {

        public async Task<List<string>> GetFriends()
        {
            //Web requests, REST API
            await Task.Delay(10000);
            return new List<string>() { "Clara", "Sarah", "William" };
        }
    }
}