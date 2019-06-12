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
        public MainPage(IMainViewModel mainViewModel)
        {
            InitializeComponent();
            BindingContext = mainViewModel;
        }

        private void ChangeStyle(object sender, EventArgs e)
        {
            IsUsingLightButtonStyle = !IsUsingLightButtonStyle;

            if (IsUsingLightButtonStyle)
            {
                Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["LightButtonStyle"];
            }
            else
            {
                Application.Current.Resources["ButtonStyle"] = Application.Current.Resources["DarkButtonStyle"];
            }

        }

        private bool IsUsingLightButtonStyle { get; set; }
    }
}
