using System;
using System.ComponentModel;
using FriendsApp.ViewModels;
using Xamarin.Forms;

namespace FriendsApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private IMainViewModel m_mainViewModel;
        private bool m_isUsingLightButtonStyle;

        public MainPage(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = m_mainViewModel = mainViewModel;
        }

        private void ChangeStyle(object sender, EventArgs e)
        {
            m_isUsingLightButtonStyle = !m_isUsingLightButtonStyle;

            if (m_isUsingLightButtonStyle)
            {
                Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["LightButtonStyle"];
            }
            else
            {
                Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["DarkButtonStyle"];
            }

        }


        public async void OnStart()
        {
            await m_mainViewModel.Initialize();
        }
    }
}
