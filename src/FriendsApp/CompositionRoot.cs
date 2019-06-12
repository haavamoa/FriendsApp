using FriendsApp.Services;
using FriendsApp.ViewModels;
using FriendsApp.Views;
using LightInject;

namespace FriendsApp
{
    public class CompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IFriendService, FriendService>(new PerContainerLifetime());
            serviceRegistry.Register<IMainViewModel, MainViewModel>(new PerContainerLifetime());
            serviceRegistry.Register<MainPage>(new PerContainerLifetime());
        }
    }
}