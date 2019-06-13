using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FriendsApp.ViewModels
{
    public interface IMainViewModel
    {
        string NewFriendName { get; set; }
        ICommand AddFriendCommand { get; }
        ObservableCollection<FriendViewModel> Friends { get;  }
        Task Initialize();
    }
}