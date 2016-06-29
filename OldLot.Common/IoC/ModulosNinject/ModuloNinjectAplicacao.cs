using Ninject.Modules;
using OldLot.Aplicacao;
using OldLot.Aplicacao.Interfaces;
using OldLot.Dominio.Interfaces.Servicos;
using OldLot.Dominio.Servicos;

namespace OldLot.Common.IoC.ModulosNinject
{
    public class ModuloNinjectAplicacao : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IServicoBase<>)).To(typeof(ServicoBase<>));
            Bind<IServicoVeiculo>().To<ServicoVeiculo>();
            Bind<IServicoFabricante>().To<ServicoFabricante>();
            Bind<IServicoTipoDeVeiculo>().To<ServicoTipoDeVeiculo>();

            Bind(typeof(IServicoAplicacaoBase<>)).To(typeof(ServicoAplicacaoBase<>));
            Bind<IServicoAplicacaoVeiculo>().To<ServicoAplicacaoVeiculo>();
            Bind<IServicoAplicacaoFabricante>().To<ServicoAplicacaoFabricante>();
            Bind<IServicoAplicacaoTipoDeVeiculo>().To<ServicoAplicacaoTipoDeVeiculo>();
        }
    }
}
