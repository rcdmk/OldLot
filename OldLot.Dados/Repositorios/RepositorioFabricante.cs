using OldLot.Dados.Contextos;
using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Repositorios;

namespace OldLot.Dados.Repositorios
{
    public class RepositorioFabricante : RepositorioBase<Fabricante>, IRepositorioFabricante
    {
        public RepositorioFabricante(ContextoOldLot dbContext) : base(dbContext)
        {
        }
    }
}
