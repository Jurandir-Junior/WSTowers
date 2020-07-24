using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WSTower2.Models;
using WSTower2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainNovosView : ContentPage
    {
        EstadiosViewModel vm = new EstadiosViewModel(2);
        public MainNovosView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = vm;
        }

        private void btnCadastrar_Clicked(object sender, EventArgs e)
        {
            string pattern = "[0-9]{3,}";
            string verify = this.capacidade.Text;
            bool IsValid = Regex.IsMatch(verify, pattern);

            if (IsValid == true)
            {
                if (Status_Reformando.IsChecked == true)
                {
                    Estadio estadio = new Estadio
                    {
                        Nome = this.nome.Text,
                        Local = this.local.Text,
                        Capacidade = Convert.ToInt32(this.capacidade.Text),
                        Proprietario = this.proprietario.Text,
                        Status = 0
                    };
                    vm.createNovoEstadio(estadio);
                }
                else
                {
                    Estadio estadio = new Estadio
                    {
                        Nome = this.nome.Text,
                        Local = this.local.Text,
                        Capacidade = Convert.ToInt32(this.capacidade.Text),
                        Proprietario = this.proprietario.Text,
                        Status = 1
                    };
                    vm.createNovoEstadio(estadio);
                }
            } else
            {
                DisplayAlert("Erro", "O campo capacidade deve conter apenas números", "Cancelar");
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
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
                Navigation.PopAsync();
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