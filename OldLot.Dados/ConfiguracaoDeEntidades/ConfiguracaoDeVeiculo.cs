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
        }
    }
}
