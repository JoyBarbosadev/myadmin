using myadmin.Persistencia;
using Myadmin.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Gerencia
{
    public class BMLogin : BMBase
    {
        //Verifica se o token é valido
        public Boolean TokenEhValido(string token)
        {
            USUARIO dbUsuario = db.USUARIO.Where(x => x.token == token).FirstOrDefault();

            return ((db.USUARIO != null) ? dbUsuario.data_expiracao_token > DateTime.Now : false);
        }

        //Verifica se o Usuario é valido
        public Boolean UsuarioAtivo(string token)
        {
            USUARIO dbUsuario = db.USUARIO.Where(x => x.token == token).FirstOrDefault();

            if (dbUsuario == null)
                return false;
            else if (dbUsuario.ativo == "N" || dbUsuario.ativo != "S")
                return false;
            else return true;
        }

        public int RecuperarId(string token)
        {
            USUARIO dbUsuario = db.USUARIO.Where(x => x.token == token).FirstOrDefault();

            return ((dbUsuario != null) ? dbUsuario.id : 0);
        }

        public string RecuperarNome(string token)
        {
            USUARIO dbUsuario = db.USUARIO.Where(x => x.token == token).FirstOrDefault();

            return ((dbUsuario != null) ? dbUsuario.nome : "");
        }

        public Boolean Validar(string Usuario, string Senha)
        {
            USUARIO dbUsuario = db.USUARIO.Where(x => x.email == Usuario && x.senha == Senha).FirstOrDefault();

            if (dbUsuario != null)
            {
                //Se estiver Ativo, faz a renovação de token
                if (dbUsuario.data_expiracao_token < DateTime.Now || dbUsuario.data_expiracao_token == null)
                {
                    dbUsuario.token = HashMD5.getMD5Token(Senha);
                    dbUsuario.data_expiracao_token = DateTime.Now.AddDays(2);
                    dbUsuario.data_ultimo_acesso = DateTime.Now;
                }

                dbUsuario.data_ultimo_acesso = DateTime.Now;
                db.USUARIO.Attach(dbUsuario);
                db.Entry(dbUsuario).State = EntityState.Modified;
                db.SaveChanges();

                return true;
            }
            else return false;
        }

        public string RecuperarToken(String usuario, String senha)
        {
            return (db.USUARIO.Where(x => x.email == usuario && x.senha == senha).FirstOrDefault().token);
        }

    }
}
