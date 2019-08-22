using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Processo
{
    public class BPBase<T> where T : new()
    {
        public virtual T manager { get; set; }

        protected T GetObject()
        {
            return new T();
        }

        public BPBase()
        {
            manager = GetObject();
        }
    }
}
