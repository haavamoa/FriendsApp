using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using FriendsApp.Resources.LocalizedStrings;
using FriendsApp.Services;
using FriendsApp.ViewModels.Interfaces;
using Xamarin.Forms;

namespace FriendsApp.ViewModels
{
    public class MainViewModel : BaseViewModel, IMainViewModel, IHandleFriends
    {
        private readonly IFriendService m_friendService;
        private string m_newFriendName;
        private FriendViewModel m_selectedFriend;

        public MainViewModel(IFriendService friendService)
        {
            m_friendService = friendService;
            AddFriendCommand = new Command(AddFriend, () => !string.IsNullOrEmpty(NewFriendName));    
            Friends = new ObservableCollection<FriendViewModel>();
        }

        public string NewFriendName
        {
            get => m_newFriendName;

            set
            {
                SetProperty(ref m_newFriendName, value);
                ((Command)AddFriendCommand).ChangeCanExecute();
            }
        }

        public ICommand AddFriendCommand { get; }

        public void AddFriend()
        {
            var friendViewModel = new FriendViewModel(NewFriendName, this);
            Friends.Add(friendViewModel);
            NewFriendName = string.Empty;
            SelectedFriend = null;
        }

        public void OnFriendRemoved(FriendViewModel friendViewModel)
        {
            Friends.Remove(friendViewModel);
        }

        public ObservableCollection<FriendViewModel> Friends { get; }

        public async Task Initialize()
        {
            var friends = await m_friendService.GetFriends();
            foreach (var friend in friends)
            {
                Friends.Add(new FriendViewModel(friend, this));
            }
        }

        public FriendViewModel SelectedFriend
        {
            get => m_selectedFriend;
            set => SetProperty(ref m_selectedFriend, value);
        }
    }

    public class BaseViewModel : INotifyPropertyChanged
    {

        public void SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return;
            backingField = value;
            OnPropertyChanged(propertyName);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}