using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Entidade
{
    public class BEUsuario : BEBase
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
