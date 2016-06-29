using OldLot.Aplicacao.Interfaces;
using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Servicos;

namespace OldLot.Aplicacao
{
    public class ServicoAplicacaoVeiculo : ServicoAplicacaoBase<Veiculo>, IServicoAplicacaoVeiculo
    {
        private readonly IServicoVeiculo servicoVeiculo;

        public ServicoAplicacaoVeiculo(IServicoVeiculo servico) : base(servico)
        {
            this.servicoVeiculo = servico;
        }
    }
}
