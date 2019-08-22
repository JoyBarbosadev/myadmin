using myadmin.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace myadmin.Negocio.Gerencia
{
    public class BMBase
    {
        public virtual myadmindbEntities db { get; set; }

        public BMBase() 
        {
            this.db = new myadmindbEntities();
        }
        public List<T> RawSqlQuery<T>(string query, Func<DbDataReader, T> map)
        {
            using (var command = this.db.Database.Connection.CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                this.db.Database.Connection.Open();

                var entities = new List<T>();

                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        entities.Add(map(result));
                    }
                }

                this.db.Database.Connection.Close();

                return entities;
            }
        }
        public static string RetornaErroEntity(DbEntityValidationException e)
        {
            string erro = "";
            foreach (var eve in e.EntityValidationErrors)
            {
                foreach (var ve in eve.ValidationErrors)
                {
                    erro = erro + String.Format("- Property: \"{0}\", Erro: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                }
            }
            return erro;
        }
    }
}
