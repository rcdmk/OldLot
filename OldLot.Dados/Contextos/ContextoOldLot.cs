using OldLot.Dados.ConfiguracaoDeEntidades;
using OldLot.Dados.Migrations;
using OldLot.Dominio.Entidades;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace OldLot.Dados.Contextos
{
    public class ContextoOldLot : DbContext
    {
        public ContextoOldLot()
            : base("OldLot") // Nome da connection string padrão
        {
            Database.SetInitializer<ContextoOldLot>(new MigrateDatabaseToLatestVersion<ContextoOldLot, Configuration>());
        }

        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<TipoDeVeiculo> TiposDeVeiculo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties()
                .Where(p => p.Name == "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p =>
                {
                    p.HasColumnType("varchar");
                    p.HasMaxLength(50);
                });

            modelBuilder.Configurations.Add(new ConfiguracaoDeVeiculo());
            modelBuilder.Configurations.Add(new ConfiguracaoDeFabricante());
            modelBuilder.Configurations.Add(new ConfiguracaoDeTipoDeVeiculo());
        }
    }
}
