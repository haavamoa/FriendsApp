using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FriendsApp.Services;
using FriendsApp.ViewModels;
using LightInject;
using Moq;
using Xunit;

namespace FriendsApp.Tests.ViewModels
{
    public class MainViewModelTests : TestBase
    {
        internal override void Configure(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IFriendService>(f => new Mock<IFriendService>().Object);
        }

        private readonly IMainViewModel m_mainViewModel;

        [Fact]
        public void AddFriend_NewFriendNameIsSet_FriendsHasItems()
        {
            m_mainViewModel.NewFriendName = "TestName";

            m_mainViewModel.AddFriendCommand.Execute(null);

            Assert.NotEmpty(m_mainViewModel.Friends);
        }

        [Fact]
        public void OnFriendRemoved_RemovedFriendCommandExecuted_FriendsHasNoItems()
        {
            m_mainViewModel.NewFriendName = "TestName";
            m_mainViewModel.AddFriendCommand.Execute(null);

            m_mainViewModel.Friends.First().RemoveFriendViewModel.Execute(null);

            Assert.Empty(m_mainViewModel.Friends);

        }
    }
}
