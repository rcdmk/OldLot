using OldLot.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dados.ConfiguracaoDeEntidades
{
    public class ConfiguracaoDeEntidadeBase<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : EntidadeBase
    {
        public ConfiguracaoDeEntidadeBase()
        {
            HasKey(e => e.Id);

            Property(e => e.Nome)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
