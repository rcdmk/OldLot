using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Servicos;
using OldLot.Dominio.Interfaces.Repositorios;

namespace OldLot.Dominio.Servicos
{
    public class ServicoVeiculo : ServicoBase<Veiculo>, IServicoVeiculo
    {
        private readonly IRepositorioVeiculo repositorioVeiculo;

        public ServicoVeiculo(IRepositorioVeiculo repositorio) : base(repositorio)
        {
            this.repositorioVeiculo = repositorio;
        }
    }
}
