using myadmin.Negocio.Entidade;
using myadmin.Negocio.Gerencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Processo
{
    public class BPUsuario :BPBase<BMUsuario>
    {
        public Boolean ValidaUnidade(BEUsuario entidade)
        {
            return manager.ValidadeUnidade(entidade);
        }

       

        public Boolean InserirOuAtualizar(BEUsuario entidade)
        {
            return manager.InserirOuAtualizar(entidade);
        }
    }
}
