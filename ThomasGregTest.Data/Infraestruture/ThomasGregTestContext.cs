using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ThomasGregTest.Data.Entity;
using ThomasGregTest.Data.Mapping;

namespace ThomasGregTest.Data.Infraestruture
{
    public class ThomasGregTestContext : DbContext
    {
        public ThomasGregTestContext() : base("dbContextConnection")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMapping());
            modelBuilder.Configurations.Add(new LogradouroMapping());

            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Logradouro> Logradouros { get; set; }

    }
}
