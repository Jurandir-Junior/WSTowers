using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSTowersAPI.Controllers
{
    public class LoginViewModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
