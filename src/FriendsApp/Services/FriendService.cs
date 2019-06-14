using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using FriendsApp.Services.Http;
using FriendsApp.ViewModels;
using Newtonsoft.Json;

namespace FriendsApp.Services
{
    public class FriendService : IFriendService
    {
        private readonly IHttpClient m_httpClient;

        private const string BaseAddress =
            "https://raw.githubusercontent.com/haavamoa/FriendsApp.Blueprint/dependency-injection/src/FriendsApp.Blueprint/Services/friends.json";

        public FriendService(IHttpClientFactory httpClientFactory)
        {
            m_httpClient = httpClientFactory.Create();
        }

        public async Task<List<string>> GetFriends()
        {
            var friends = new List<string>();
            try
            {
                var response = await m_httpClient.GetAsync(new Uri(BaseAddress));
                var friendsModels = JsonConvert.DeserializeObject<List<string>>(response);
                friendsModels.ForEach(s => friends.Add(s));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                //Show something for the user
            }

            return friends;
        }
    }
}