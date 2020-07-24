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
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button1_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainConcluidosView());
        }

        private void Button2_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainReformaView());
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainNovosView());
        }

        private void Button4_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SobreView());
        }
    }
}