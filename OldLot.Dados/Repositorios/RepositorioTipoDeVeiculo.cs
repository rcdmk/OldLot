using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace OldLot.Dados.Repositorios
{
    public class RepositorioTipoDeVeiculo : RepositorioBase<TipoDeVeiculo>, IRepositorioTipoDeVeiculo
    {
        public RepositorioTipoDeVeiculo(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
