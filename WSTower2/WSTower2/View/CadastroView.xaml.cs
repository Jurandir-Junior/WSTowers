using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WSTower2.ViewModels;
using WSTowersAPI.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroView : ContentPage
    {
        LoginViewModel vm = new LoginViewModel();
        public CadastroView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = vm;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private void btnCadastro_Clicked(object sender, EventArgs e)
        {
            bool result = verifyInputs();

            if (result == true)
            {
                Usuario usuario = new Usuario
                {
                    Nome = this.nome.Text,
                    Email = this.email.Text,
                    Senha = this.senha.Text
                };
                vm.cadastro(usuario);

                nome.Text = "";
                email.Text = "";
                senha.Text = "";

                DisplayAlert("Sucesso", "Usuário cadastrado com sucesso!", "OK");
            }
            else if (result == false)
            {
                DisplayAlert("Erro", "O servidor retornou um erro", "OK");
            }
            else
            {
                DisplayAlert("Erro", "Ocorreu um erro desconhecido!", "OK");
            }
        }

        private bool verifyEmail()
        {
            string pattern = "[a-zA-Z]{1}[a-zA-Z0-9]{3,}[-_.]{0,1}[a-zA-Z0-9]{4,}[@]{1}[a-zA-Z]{3,}[.]{1}[a-zA-Z]{2,}";

            if (!Regex.IsMatch(email.Text, pattern) || string.IsNullOrEmpty(email.Text))
            {
                return false;
            }

            return true;
        }

        public bool verifyInputs()
        {
            bool result = verifyEmail();
            if (!string.IsNullOrEmpty(nome.Text) && nome.Text.Trim().Length >= 3 &&
                result == true &&
                !string.IsNullOrEmpty(senha.Text) && senha.Text.Trim().Length >= 3
                )
            {
                return true;
            }
            return false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "ErroCadastro", (str) =>
            {
                DisplayAlert("Erro", str, "Cancelar");
            });

            MessagingCenter.Subscribe<string>(this, "SucessoCadastro", (str) =>
            {
                App.Current.MainPage = new NavigationPage(new LoginView());
            });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<string>(this, "ErroCadastro");
            MessagingCenter.Unsubscribe<string>(this, "SucessoCadastro");
        }
    }
}