using System.Data.Entity;
using PFlow_Database.Administrativo.Entities;

namespace PFlow_Database.Administrativo
{
    public class PFlowContext: DbContext
    {
        public PFlowContext(): base("name=PFlowConnectionString")
        { }

        public DbSet<PessoaDB> Pessoas { get; set; }
    }
}