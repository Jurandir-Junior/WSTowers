using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSTower2.ViewModels;
using WSTowersAPI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        LoginViewModel vm = new LoginViewModel();
        public LoginView()
        {
            InitializeComponent();
            this.BindingContext = vm;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroView());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "ErroLogin", (str) =>
            {
                DisplayAlert("Erro", str, "Cancelar");
            });

            MessagingCenter.Subscribe<string>(this, "SucessoLogin", (str) =>
            {
                App.Current.MainPage = new NavigationPage(new MenuView());
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "ErroLogin");
            MessagingCenter.Unsubscribe<string>(this, "SucessoLogin");
        }

        private void btnLogar_Clicked(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario
            {
                Email = this.email.Text,
                Senha = this.senha.Text
            };
            vm.login(usuario);
        }
    }
}