using OldLot.Aplicacao.Interfaces;
using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Servicos;

namespace OldLot.Aplicacao
{
    public class ServicoAplicacaoTipoDeVeiculo : ServicoAplicacaoBase<TipoDeVeiculo>, IServicoAplicacaoTipoDeVeiculo
    {
        private readonly IServicoTipoDeVeiculo servicoTipoDeVeiculo;

        public ServicoAplicacaoTipoDeVeiculo(IServicoTipoDeVeiculo servico) : base(servico)
        {
            this.servicoTipoDeVeiculo = servico;
        }
    }
}
