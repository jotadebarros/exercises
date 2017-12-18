using System.Data.Entity.ModelConfiguration;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Infra.Data.EntityConfig
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            //Chave Primaria
            HasKey(c => c.RoleId);

            // Properties
            Property(c => c.Name).IsRequired();

            // Tabela & coluna Mapeamentos
            ToTable("Role ");
            Property(c => c.RoleId).HasColumnName("RoleId");
            Property(c => c.Name).HasColumnName("Name");

        }
    }
}
