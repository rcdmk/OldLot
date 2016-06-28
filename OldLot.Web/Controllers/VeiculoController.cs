using AutoMapper;
using OldLot.Aplicacao;
using OldLot.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OldLot.Web.Controllers
{
    public class VeiculoController : Controller
    {
        private ServicoAplicacaoVeiculo servico;

        public VeiculoController(ServicoAplicacaoVeiculo servico)
        {
            this.servico = servico;
        }

        // GET: Veiculo
        public ActionResult Index()
        {
            var veiculos = Mapper.Map<IEnumerable<VeiculoViewModel>>(servico.ObterTodos());

            return View(veiculos);
        }
    }
}