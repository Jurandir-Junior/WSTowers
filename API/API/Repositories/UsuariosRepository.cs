using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowersAPI.Controllers;
using WSTowersAPI.Models;

namespace WSTowersAPI.Repositories
{
    public class UsuariosRepository
    {
        private static List<Usuario> usuarios;
        private static int contador = 1;

        public UsuariosRepository()
        {
            if (usuarios == null)
            {
                usuarios = new List<Usuario>
                {
                    new Usuario
                    {
                        Id = contador,
                        Nome = "Jurandir Junior",
                        Email = "jurandir.junior@email.com",
                        Senha = "123456"
                    }
                };
                contador++;
            }
        }

        public void add(Usuario usuario)
        {
            contador++;
            usuario.Id = contador;
            usuarios.Add(usuario);
        }

        public Usuario buscarPorEmailSenha(LoginViewModel loginViewModel)
        {
            return usuarios.FirstOrDefault(
                x => x.Email == loginViewModel.email && x.Senha == loginViewModel.senha);
        }
    }
}
