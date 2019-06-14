using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FriendsApp.Services;
using FriendsApp.Services.Http;
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
            m_httpClientMock = new Mock<IHttpClient>();
            serviceRegistry.Register(f => m_httpClientMock.Object);
        }

        private readonly IMainViewModel m_mainViewModel;
        private Mock<IHttpClient> m_httpClientMock;

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

        [Fact]
        public async void Initialize_ServiceHasFriends_FriendsGetsSet()
        {
            m_httpClientMock.Setup(s => s.GetAsync(It.IsAny<Uri>())).ReturnsAsync("[\"Carl\"]");

            await m_mainViewModel.Initialize();

            Assert.NotEmpty(m_mainViewModel.Friends);
        }
    }
}
