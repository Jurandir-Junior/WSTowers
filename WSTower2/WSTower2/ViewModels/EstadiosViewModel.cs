using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using WSTower2.Models;
using WSTower2.Services;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace WSTower2.ViewModels
{
    public class EstadiosViewModel : BaseViewModel
    {
        private List<Estadio> _estadios;

        public List<Estadio> estadios
        {
            get { return _estadios;  }
            set
            {
                _estadios = value;
                OnPropertyChanged();
            }
        }

        public ICommand btnAdicionarCommand { get; set; }

        public EstadiosViewModel(int valor)
        {
            estadios = new List<Estadio>();

            if (valor == 1)
            {
                getEstadiosConcluidos();
            }
            else if (valor == 0)
            {
                getEstadiosIncompletos();
            }
        }

        public void getEstadiosConcluidos()
        {
            HttpClient client = Utils.getClient;

            HttpResponseMessage response = client.GetAsync("estadios/concluidos").Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                estadios = JsonConvert.DeserializeObject<List<Estadio>>(json);
            }
        }

        public void getEstadiosIncompletos()
        {
            HttpClient client = Utils.getClient;

            HttpResponseMessage response = client.GetAsync("estadios/reforma").Result;

            if (response.IsSuccessStatusCode)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                estadios = JsonConvert.DeserializeObject<List<Estadio>>(json);
            }
        }

        public void createNovoEstadio(Estadio novoEstadio)
        {
            HttpClient client = Utils.getClient;

            Estadio estadio = new Estadio
            {
                Nome = novoEstadio.Nome,
                Local = novoEstadio.Local,
                Capacidade = novoEstadio.Capacidade,
                Proprietario = novoEstadio.Proprietario,
                Status = novoEstadio.Status
            };

            string objectSerialized = JsonConvert.SerializeObject(estadio);

            StringContent content = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("estadios/novo", content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessagingCenter.Send<string>("", "SucessoCadastro");
            }
            else
            {
                MessagingCenter.Send<String>($"Erro no servidor: StatusCode = {response.StatusCode.ToString()}", "ErroCadastro");
            }
        }
    }
}
