using OldLot.Aplicacao.Interfaces;
using OldLot.Dominio.Entidades;
using OldLot.Dominio.Interfaces.Servicos;

namespace OldLot.Aplicacao
{
    public class ServicoAplicacaoFabricante : ServicoAplicacaoBase<Fabricante>, IServicoAplicacaoFabricante
    {
        private readonly IServicoFabricante servicoFabricante;

        public ServicoAplicacaoFabricante(IServicoFabricante servico) : base(servico)
        {
            this.servicoFabricante = servico;
        }
    }
}
