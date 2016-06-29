using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Repositorios;
using OldLot.Dominio.Interfaces.Servicos;

namespace OldLot.Dominio.Servicos
{
    public class ServicoTipoDeVeiculo : ServicoBase<TipoDeVeiculo>, IServicoTipoDeVeiculo
    {
        private readonly IRepositorioTipoDeVeiculo repositorioTipoDeVeiculo;

        public ServicoTipoDeVeiculo(IRepositorioTipoDeVeiculo repositorio) : base(repositorio)
        {
            this.repositorioTipoDeVeiculo = repositorio;
        }
    }
}
