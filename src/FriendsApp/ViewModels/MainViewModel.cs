using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace FriendsApp.ViewModels
{
    public class MainViewModel
    {
        public MainViewModel()
        {
            AddFriendCommand = new Command(AddFriend);    
            Friends = new ObservableCollection<FriendViewModel>();
        }

        public string NewFriendName { get; set; }
        public ICommand AddFriendCommand { get; }

        public void AddFriend()
        {
            Friends.Add(new FriendViewModel(NewFriendName));
        }

        public ObservableCollection<FriendViewModel> Friends { get; }
    }
}