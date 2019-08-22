using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Entidade
{
    public class BEBase
    {
        public virtual List<String> erros { get; set; }

        public virtual void AddError(String error)
        {
            this.erros.Add(error);
        }

        public virtual Boolean isValid()
        {
            return (this.erros.Count == 0);
        }

        public BEBase()
        {
            this.erros = new List<string>();
        }
    }
}
