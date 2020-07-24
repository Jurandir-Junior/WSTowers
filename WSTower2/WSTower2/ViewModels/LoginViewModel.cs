using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using WSTower2.Models;
using WSTower2.Services;
using WSTowersAPI.Models;
using Xamarin.Forms;

namespace WSTower2.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public ICommand btnLoginCommand { get; set; }
        public ICommand btnCadastroCommand { get; set; }

        public LoginViewModel()
        {
            
        }

        public void cadastro(Usuario novoUsuario)
        {
            HttpClient client = Utils.getClient;

            Usuario usuario = new Usuario
            {
                Nome = novoUsuario.Nome,
                Email = novoUsuario.Email,
                Senha = novoUsuario.Senha
            };

            string objectSerialized = JsonConvert.SerializeObject(usuario);

            StringContent content = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("usuarios/cadastro", content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessagingCenter.Send<string>("", "SucessoCadastro");
            }
            else
            {
                MessagingCenter.Send<String>($"Erro no servidor: StatusCode = {response.StatusCode.ToString()}", "ErroCadastro");
            }
        }

        public void login(Usuario usuario)
        {
            HttpClient client = Utils.getClient;

            Login login = new Login
            {
                email = usuario.Email,
                senha = usuario.Senha
            };

            string objectSerialized = JsonConvert.SerializeObject(login);

            StringContent content = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync("usuarios/login", content).Result;

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string json = response.Content.ReadAsStringAsync().Result;

                Token token = JsonConvert.DeserializeObject<Token>(json);
                MessagingCenter.Send<string>("", "SucessoLogin");
            }
            else if (response.StatusCode == HttpStatusCode.NoContent)
            {
                MessagingCenter.Send<String>("Usuário não encontrado", "ErroLogin");
            }
            else
            {
                MessagingCenter.Send<String>($"Erro no servidor: StatusCode = {response.StatusCode.ToString()}", "ErroLogin");
            }
        }

        private class Token
        {
            public string token { get; set; }
        }
    }
}
