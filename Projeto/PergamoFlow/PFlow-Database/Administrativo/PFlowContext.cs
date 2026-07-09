using System.Data.Entity;
using PFlow_Database.Administrativo;

namespace PFlow_Database.Administrativo
{
    public class PFlowContext: DbContext
    {
        public PFlowContext(): base("name=PFlowConnectionString")
        { }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
