using System.Data.Entity.ModelConfiguration;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Infra.Data.EntityConfig
{
    public class DependentConfiguration : EntityTypeConfiguration<Dependent>
    {
        public DependentConfiguration()
        {
            //Chave Primaria
            HasKey(c => c.DependentId);

            //Properties
            Property(c => c.Name).IsRequired();

            //Tabela & coluna Mapeamentos
            ToTable("Dependent");
            Property(c => c.DependentId).HasColumnName("DependentId");
            Property(c => c.Name).HasColumnName("Name");

            HasRequired(p => p.Employee)
                .WithMany(p => p.Dependents)
                .HasForeignKey(p => p.EmployeeId)
                .WillCascadeOnDelete(true);

            Ignore(p => p.Excluido);

        }
    }
}