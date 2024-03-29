using System.Data.Entity.ModelConfiguration;
using ThomasGregTest.Data.Entity;

namespace ThomasGregTest.Data.Mapping
{
    public class ClienteMapping : EntityTypeConfiguration<Cliente>
    {
        public ClienteMapping(string schema = "dbo.")
        {
            ToTable(schema + "Cliente");
            HasKey(x => x.ClienteId);
            Property(x => x.ClienteId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).HasColumnName("ClienteId");
            Property(x => x.Nome).HasColumnName("Nome").IsRequired().HasMaxLength(200);
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(100);

        }
    }
}
