using System.Collections.Generic;
using System.Threading.Tasks;

namespace FriendsApp.Services
{
    public interface IFriendService
    {
        Task<List<string>> GetFriends();
    }
}