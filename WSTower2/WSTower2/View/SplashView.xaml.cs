using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashView : ContentPage
    {
        public SplashView()
        {
            InitializeComponent();

            Timer();
        }

        private void Timer()
        {
            Device.StartTimer(new TimeSpan(0, 0, 5), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    App.Current.MainPage = new NavigationPage(new LoginView());
                });
                return false;
            });
        }
    }
}