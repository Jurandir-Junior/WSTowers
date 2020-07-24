using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace WSTower2.Models
{
    public class Estadio
    {
        
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Local { get; set; }
        public int Capacidade { get; set; }
        public string Proprietario { get; set; }
        public int Status { get; set; }
        public ImageSource Icon { get; set; }

        public override string ToString()
        {
            return Nome;
        }
    }
}
