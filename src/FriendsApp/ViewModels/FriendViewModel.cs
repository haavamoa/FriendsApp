using System;
using System.Windows.Input;
using FriendsApp.ViewModels.Interfaces;
using Xamarin.Forms;

namespace FriendsApp.ViewModels
{
    public class FriendViewModel
    {
        private readonly IHandleFriends m_friendsHandler;

        public FriendViewModel(string name, IHandleFriends friendsHandler)
        {
            m_friendsHandler = friendsHandler;
            Name = name;
            RemoveFriendViewModel = new Command(RemoveFriend);
        }
        public string Name { get; }

        public ICommand RemoveFriendViewModel { get; }

        public void RemoveFriend()
        {
            //How to communicate that we want to be deleted?
            //Event? CallBack? Interface?
            m_friendsHandler.OnFriendRemoved(this);
            
        }

    }
}