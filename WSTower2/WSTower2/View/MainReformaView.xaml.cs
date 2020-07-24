using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WSTower2.Models;
using WSTower2.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WSTower2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainReformaView : ContentPage
    {
        EstadiosViewModel vm = new EstadiosViewModel(0);
        EstadiosViewModel vm2 = new EstadiosViewModel(1);
        public MainReformaView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = vm;
            foreach (Estadio estadio in vm.estadios)
            {
                if (estadio.Status == 0)
                {
                    estadio.Icon = "fechar.png";
                }
            }
            estCon.Text = CountConcluidos().ToString();
            estRef.Text = CountReformas().ToString();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public int CountConcluidos()
        {
            int Concluidos = vm2.estadios.Count;


            return Concluidos;
        }

        public int CountReformas()
        {
            int Reformas = vm.estadios.Count;

            return Reformas;
        }
    }
}