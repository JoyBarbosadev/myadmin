using myadmin.Negocio.Gerencia;
using Myadmin.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Processo
{
    public class BPLogin : BPBase<BMLogin>
    {
        public Boolean Validar(string Usuario, string senha)

        {
            if(Usuario == "" || senha == "")
            {
                throw new Exception("Usuario e senha não foram preenchido corretamente");
            }
            else
            {
                return this.manager.Validar(Usuario, HashMD5.getMD5Senha(senha));
            }
        }

        public String RecuperarToken(string usuario, string senha)
        {
            return this.manager.RecuperarToken(usuario, HashMD5.getMD5Senha(senha));
        }

        public string RecuperarNome(string token)
        {
            return this.manager.RecuperarNome(token);
        }

        public int RecuperarId(string token)
        {
            return this.manager.RecuperarId(token);
        }

        public Boolean TokenEhValido(String token)
        {
            return this.manager.TokenEhValido(token);
        }

        public Boolean UsuarioAtivo(String token)
        {
            return this.manager.UsuarioAtivo(token);
        }

    }
}
