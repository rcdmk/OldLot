using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Repositorios;
using OldLot.Dominio.Interfaces.Servicos;

namespace OldLot.Dominio.Servicos
{
    public class ServicoFabricante : ServicoBase<Fabricante>, IServicoFabricante
    {
        private readonly IRepositorioFabricante repositorioFabricante;

        public ServicoFabricante(IRepositorioFabricante repositorio) : base(repositorio)
        {
            this.repositorioFabricante = repositorio;
        }
    }
}
