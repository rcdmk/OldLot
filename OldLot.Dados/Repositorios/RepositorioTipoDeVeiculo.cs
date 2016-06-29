using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Repositorios;
using OldLot.Dados.Contextos;

namespace OldLot.Dados.Repositorios
{
    public class RepositorioTipoDeVeiculo : RepositorioBase<TipoDeVeiculo>, IRepositorioTipoDeVeiculo
    {
        public RepositorioTipoDeVeiculo(ContextoOldLot dbContext) : base(dbContext)
        {
        }
    }
}
