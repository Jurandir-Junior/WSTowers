using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSTower2.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstadioInfoView : ContentPage
    {
        public EstadioInfoView(Estadio selectedItem)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _nome.Text = selectedItem.Nome;
            _local.Text = selectedItem.Local;
            _capacidade.Text = selectedItem.Capacidade.ToString();
            _proprietario.Text = selectedItem.Proprietario;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}