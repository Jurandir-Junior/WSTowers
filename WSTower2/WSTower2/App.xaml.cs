using System;
using WSTower2.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashView();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
