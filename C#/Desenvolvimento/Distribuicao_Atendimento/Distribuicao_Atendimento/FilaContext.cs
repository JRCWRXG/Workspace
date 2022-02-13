using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Distribuicao_Atendimento
{
   public class FilaContext: DbContext
    {
        public FilaContext() : base("Name=OBZEEntities")
        {
            Database.SetInitializer<FilaContext>(
                new CreateDatabaseIfNotExists<FilaContext>());
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
               
        }

        public DbSet<Fila> Filas { get; set; }
        public DbSet<Atendente> Atendentes { get; set; }
    }
}
