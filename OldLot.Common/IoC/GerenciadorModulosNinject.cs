using Ninject.Modules;
using OldLot.Common.IoC.ModulosNinject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Common.IoC
{
    public class GerenciadorModulosNinject
    {
        private GerenciadorModulosNinject()
        {
            throw new InvalidOperationException("Não é permitido instanciar esta classe.");
        }

        public static IList<INinjectModule> ObterModulos()
        {
            return new List<INinjectModule>()
            {
                new ModuloNinjectDados(),
                new ModuloNinjectAplicacao()
            };
        }
    }
}
