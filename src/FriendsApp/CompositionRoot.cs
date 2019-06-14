using System.Net.Http;
using FriendsApp.Services;
using FriendsApp.Services.Http;
using FriendsApp.ViewModels;
using FriendsApp.Views;
using LightInject;

namespace FriendsApp
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IHttpClient, HttpClientWrapper>();
            serviceRegistry.Register<IHttpClientFactory, HttpClientFactory>();
            serviceRegistry.Register<IFriendService, FriendService>(new PerContainerLifetime());
            serviceRegistry.Register<IMainViewModel, MainViewModel>(new PerContainerLifetime());
            serviceRegistry.Register<MainPage>(new PerContainerLifetime());
        }
    }
}