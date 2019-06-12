using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FriendsApp.ViewModels;
using Xunit;

namespace FriendsApp.Tests.ViewModels
{
    public class MainViewModelTests
    {
        [Fact]
        public void AddFriend_NewFriendNameIsSet_FriendsHasItems()
        {
            var mainViewModel = new MainViewModel();

            mainViewModel.NewFriendName = "TestName";

            mainViewModel.AddFriendCommand.Execute(null);

            Assert.NotEmpty(mainViewModel.Friends);
        }

        [Fact]
        public void OnFriendRemoved_RemovedFriendCommandExecuted_FriendsHasNoItems()
        {
            var mainViewModel = new MainViewModel();
            mainViewModel.NewFriendName = "TestName";
            mainViewModel.AddFriendCommand.Execute(null);

            mainViewModel.Friends.First().RemoveFriendViewModel.Execute(null);

            Assert.Empty(mainViewModel.Friends);

        }
    }
}
