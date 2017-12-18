using System.Data.Entity.ModelConfiguration;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Infra.Data.EntityConfig
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            //Chave Primaria
            HasKey(c => c.EmployeeId);

            // Properties
            Property(c => c.Name).IsRequired();
            Property(c => c.Email).IsOptional();
            Property(c => c.Gender).IsRequired().HasMaxLength(1).HasColumnType("char");
            Property(c => c.Birth).IsRequired().HasColumnType("datetime"); ;
            Property(c => c.RoleId).IsOptional();

            // Tabela & coluna Mapeamentos
            ToTable("Employee");
            Property(c => c.EmployeeId).HasColumnName("EmployeeId");
            Property(c => c.Name).HasColumnName("Name");
            Property(c => c.Email).HasColumnName("Email");
            Property(c => c.Gender).HasColumnName("Gender");
            Property(c => c.Birth).HasColumnName("Birth");
            Property(c => c.RoleId).HasColumnName("RoleId");

            //Relacionamentos
            HasOptional(p => p.Role)
                .WithMany()
                .HasForeignKey(p => p.RoleId);

            Ignore(p => p.Rows);

        }
    }
}
