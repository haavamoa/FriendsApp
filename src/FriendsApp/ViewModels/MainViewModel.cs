using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using FriendsApp.Resources.LocalizedStrings;
using FriendsApp.Services;
using FriendsApp.ViewModels.Interfaces;
using Xamarin.Forms;

namespace FriendsApp.ViewModels
{
    public class MainViewModel : IMainViewModel, IHandleFriends
    {
        private readonly IFriendService m_friendService;

        public MainViewModel(IFriendService friendService)
        {
            m_friendService = friendService;
            var friends = m_friendService.GetFriends();

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