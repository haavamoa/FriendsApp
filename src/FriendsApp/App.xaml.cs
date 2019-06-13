using System;
using FriendsApp.Views;
using LightInject;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FriendsApp
{
    public partial class App : Application
    {
        private ServiceContainer m_container;
        private MainPage m_mainPage;

        public App()
        {
            InitializeComponent();
            m_container = new ServiceContainer(new ContainerOptions() { EnablePropertyInjection = false });
            m_container.RegisterFrom<CompositionRoot>();
            MainPage = m_mainPage =  m_container.GetInstance<MainPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            Current.Resources["ButtonStyle"] = Current.Resources["DarkButtonStyle"];
            m_mainPage.OnStart();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
