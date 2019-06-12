using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace FriendsApp.ViewModels
{
    public class FriendViewModel
    {
        public FriendViewModel(string name)
        {
            Name = name;
            RemoveFriendCommand = new Command(RemoveFriend);
        }
        public string Name { get; }

        public ICommand RemoveFriendCommand { get; }

        public void RemoveFriend()
        {
            //How to communicate that we want to be deleted?
            //Event? CallBack? Interface?
        }

    }
}