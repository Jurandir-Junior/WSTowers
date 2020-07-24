using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSTowersAPI.Models;

namespace WSTowersAPI.Repositories
{
    public class EstadiosRepository
    {
        private static List<Estadio> estadios;
        private static int contador = 1;

        public EstadiosRepository()
        {
            if (estadios == null)
            {
                
                estadios = new List<Estadio>
                {
                    new Estadio
                    {
                        Id = 1,
                        Nome = "Estadio 1",
                        Local = "L1",
                        Capacidade = 5000,
                        Proprietario = "Teste",
                        Status = 1
                    },

                    new Estadio
                    {
                        Id = 2,
                        Nome = "Estadio 2",
                        Local = "L2",
                        Capacidade = 7000,
                        Proprietario = "Teste 2",
                        Status = 1
                    },

                    new Estadio
                    {
                        Id = 3,
                        Nome = "Estadio 3",
                        Local = "L3",
                        Capacidade = 10000,
                        Proprietario = "Teste 1",
                        Status = 0
                    },

                    new Estadio
                    {
                        Id = 4,
                        Nome = "Estadio 4",
                        Local = "Local 4",
                        Capacidade = 12000,
                        Proprietario = "Teste 2",
                        Status = 0
                    }
                };
            }
        }

        public List<Estadio> GetAllReady()
        {
            return estadios.FindAll(e => e.Status == 1);
        }

        public List<Estadio> GetAllNonReady()
        {
            return estadios.FindAll(e => e.Status == 0);
        }

        public void Add(Estadio estadio)
        {
            contador++;
            estadio.Id = contador;
            estadios.Add(estadio);
        }
    }
}
