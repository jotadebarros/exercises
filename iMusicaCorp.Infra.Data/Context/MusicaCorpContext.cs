using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Infra.Data.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace iMusicaCorp.Infra.Data.Context
{
    public class MusicaCorpContext : DbContext
    {
        public MusicaCorpContext() : base("iMusicaCorp")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Dependent> Dependents { get; set; }
        public DbSet<Role> Roles { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            /*Desabilitamos o delete em cascata em relacionamentos 1:N evitando ter registros filhos sem registros pai*/
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            ////Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));


            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new DependentConfiguration());
        }
    }
}
