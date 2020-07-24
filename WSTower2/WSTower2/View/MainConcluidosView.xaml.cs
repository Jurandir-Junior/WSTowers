using System;
using System.Collections.Generic;
using System.IO;
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
    public partial class MainConcluidosView : ContentPage
    {
        EstadiosViewModel vm = new EstadiosViewModel(1);
        EstadiosViewModel vm2 = new EstadiosViewModel(0);
        public MainConcluidosView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = vm;
            foreach (Estadio estadio in vm.estadios)
            {
                if (estadio.Status == 1)
                {
                    estadio.Icon = "carraca.png";
                }
            }
            estCon.Text = CountConcluidos().ToString();
            estRef.Text = CountReformas().ToString();
        }

        private void btnVoltar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        public int CountConcluidos()
        {
            int Concluidos = vm.estadios.Count;
            

            return Concluidos;
        }

        public int CountReformas()
        {
            int Reformas = vm2.estadios.Count;

            return Reformas;
        }
    }
}