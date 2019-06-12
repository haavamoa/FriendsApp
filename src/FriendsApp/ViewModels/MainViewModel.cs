using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FriendsApp.Resources.LocalizedStrings;
using FriendsApp.ViewModels.Interfaces;
using Xamarin.Forms;

namespace FriendsApp.ViewModels
{
    public class MainViewModel : IHandleFriends
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
            var friendViewModel = new FriendViewModel(NewFriendName, this);
            Friends.Add(friendViewModel);
        }

        public void OnFriendRemoved(FriendViewModel friendViewModel)
        {
            Friends.Remove(friendViewModel);
        }

        public ObservableCollection<FriendViewModel> Friends { get; }
    }
}