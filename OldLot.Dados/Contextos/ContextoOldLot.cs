using OldLot.Dados.ConfiguracaoDeEntidades;
using OldLot.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dados.Contextos
{
    public class ContextoOldLot : DbContext
    {
        public ContextoOldLot()
            : base("OldLot") // Nome da connection string padrão
        {
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
