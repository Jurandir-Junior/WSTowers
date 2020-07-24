using System;
using System.Collections.Generic;
using System.Text;

namespace WSTowersAPI.Models
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public int Capacidade { get; set; }
        public string Proprietario { get; set; }
        public string Descricao { get; set; }
        public int Status { get; set; }
        public byte[] Imagem { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
