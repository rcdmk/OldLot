namespace OldLot.Dados.Migrations
{
    using Dominio.Entidades;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OldLot.Dados.Contextos.ContextoOldLot>
    {
        public Configuration()
        {
            ContextKey = "OldLot.Dados.Contextos.ContextoOldLot";
            AutomaticMigrationsEnabled = false;
            // AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(OldLot.Dados.Contextos.ContextoOldLot context)
        {
            var chevrollet = new Fabricante() { Id = 1, Nome = "Chevrollet" };
            var esportivo = new TipoDeVeiculo() { Id = 1, Nome = "Esportivo", Habilidades = "Potente, rápida aceleração, mas com alto consumo" };

            context.Fabricantes.AddOrUpdate(f => f.Id,
                chevrollet,
                new Fabricante() { Id = 2, Nome = "Ford" },
                new Fabricante() { Id = 3, Nome = "BMW" }
            );

            context.TiposDeVeiculo.AddOrUpdate(t => t.Id,
                esportivo,
                new TipoDeVeiculo() { Id = 2, Nome = "Utilitário", Habilidades = "Econômico, versátil, mas não muito potente" }
            );

            context.Veiculos.AddOrUpdate(v => v.Id,
                new Veiculo() { Id = 1, Nome = "Opala", Ano = 1963, Fabricante = chevrollet, Tipo = esportivo }
            );
        }
    }
}
