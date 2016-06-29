using OldLot.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoDeVeiculo : ConfiguracaoDeEntidadeBase<Veiculo>
    {
        public ConfiguracaoDeVeiculo() : base()
        {
            Property(v => v.Ano)
                .IsRequired();

            HasRequired<Fabricante>(v => v.Fabricante)
                .WithMany(f => (ICollection<Veiculo>)f.Veiculos)
                .Map(mc =>
                {
                    mc.MapKey("IdFabricante");
                });

            HasRequired<TipoDeVeiculo>(v => v.Tipo)
                .WithMany(t => (ICollection<Veiculo>)t.Veiculos)
                .Map(mc =>
                {
                    mc.MapKey("IdTipoDeVeiculo");
                });
        }
    }
}
