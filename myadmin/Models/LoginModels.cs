using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace myadmin.Models
{
    public class LoginModels
    {
        [DisplayName("Usuário")]
        public string usuario { get; set; }

        [DisplayName("Senha")]
        public string senha { get; set; }

        public Boolean ativo { get; set; }
    }
}