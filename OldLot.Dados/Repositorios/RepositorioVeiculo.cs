using OldLot.Dados.Contextos;
using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Repositorios;

namespace OldLot.Dados.Repositorios
{
    public class RepositorioVeiculo : RepositorioBase<Veiculo>, IRepositorioVeiculo
    {
        public RepositorioVeiculo(ContextoOldLot dbContext) : base(dbContext)
        {

        }
    }
}
