using System.Data.Entity.ModelConfiguration;
using ThomasGregTest.Data.Entity;

namespace ThomasGregTest.Data.Mapping
{
    public class LogradouroMapping : EntityTypeConfiguration<Logradouro>
    {
        public LogradouroMapping(string schema = "dbo.")
        {
            ToTable(schema + "Logradouro");
            HasKey(x => x.LogradouroId);

            Property(x => x.LogradouroId).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity).IsRequired().HasColumnName("LogradouroId");
            Property(x => x.LogradouroNome).HasColumnName("LogradouroNome").IsRequired().HasMaxLength(250);
            Property(x => x.ClienteId).HasColumnName("ClienteId").IsRequired();

            HasRequired(x => x.Cliente).WithMany(x => x.Logradouros).HasForeignKey(x => x.ClienteId);
        }
    }
}
