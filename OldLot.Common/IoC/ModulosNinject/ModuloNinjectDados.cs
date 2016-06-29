using Ninject.Modules;
using OldLot.Dados.Repositorios;
using OldLot.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Common.IoC.ModulosNinject
{
    public class ModuloNinjectDados : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IRepositorioBase<>)).To(typeof(RepositorioBase<>)); // sintaxe longa por causa dos genéricos
            Bind<IRepositorioVeiculo>().To<RepositorioVeiculo>();
            Bind<IRepositorioFabricante>().To<RepositorioFabricante>();
            Bind<IRepositorioTipoDeVeiculo>().To<RepositorioTipoDeVeiculo>();
        }
    }
}
