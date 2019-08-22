using myadmin.Negocio.Entidade;
using myadmin.Persistencia;
using Myadmin.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Gerencia
{
    public class BMUsuario : BMBase
    {
       public Boolean ValidadeUnidade(BEUsuario entidade)
        {
            USUARIO usuario = null;

            if(String.IsNullOrWhiteSpace(entidade.token) || String.IsNullOrEmpty(entidade.token))
            {
                usuario = db.USUARIO.Where(x => x.email == entidade.email).FirstOrDefault();
            }
            else
            {
                usuario = db.USUARIO.Where(x => x.email == entidade.email && x.token != entidade.token).FirstOrDefault();
            }
            return usuario == null;
        }
        public Boolean InserirOuAtualizar(BEUsuario entidade)
        {
            try
            {
                USUARIO usuario = (entidade.token == null ? new USUARIO() :
                   db.USUARIO.Where(x => x.token == entidade.token).FirstOrDefault());
                

                usuario.nome = entidade.nome;
                usuario.sobrenome = entidade.sobrenome;
                usuario.email = entidade.email;
                usuario.ativo = entidade.ativo;

                if (entidade.token != null)
                {
                    usuario.senha = (usuario.senha == entidade.senha ? entidade.senha : HashMD5.getMD5Senha(entidade.senha));
                    db.USUARIO.Attach(usuario);
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    usuario.token= HashMD5.getMD5Hash("HASH" + entidade.senha);
                    usuario.senha = HashMD5.getMD5Senha(entidade.senha);
                    db.USUARIO.Add(usuario);
                    db.Entry(usuario).State = EntityState.Added;
                    db.SaveChanges();
                }
                return true;
            }
            catch (DbEntityValidationException e)
            {
                string erro = RetornaErroEntity(e);
                throw new Exception(erro);
            }
        }


    }
}
