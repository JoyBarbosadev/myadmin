using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace myadmin.Models
{
    public class UsuarioModels
    {
        public int id { get; set; }
        public string senha { get; set; }
        public string token { get; set; }
        public string email { get; set; }
        public DateTime data_expiracao_token { get; set; }
        public string ativo { get; set; }
        public string nome { get; set; }
        public DateTime data_ultimo_acesso { get; set; }
        public string sobrenome { get; set; }

        
    }
}