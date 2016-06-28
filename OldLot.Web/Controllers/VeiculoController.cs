using AutoMapper;
using OldLot.Aplicacao;
using OldLot.Dominio.Entidades;
using OldLot.Web.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace OldLot.Web.Controllers
{
    public class VeiculoController : Controller
    {
        private ServicoAplicacaoVeiculo servicoVeiculos;
        private ServicoAplicacaoFabricante servicoFabricantes;
        private ServicoAplicacaoTipoDeVeiculo servicoTipos;

        public VeiculoController(ServicoAplicacaoVeiculo servicoVeiculos, ServicoAplicacaoFabricante servicoFabricantes, ServicoAplicacaoTipoDeVeiculo servicoTipos)
        {
            this.servicoVeiculos = servicoVeiculos;
            this.servicoFabricantes = servicoFabricantes;
            this.servicoTipos = servicoTipos;
        }

        // GET: Veiculo
        public ActionResult Index()
        {
            var veiculos = Mapper.Map<IEnumerable<VeiculoViewModel>>(servicoVeiculos.ObterTodos());

            return View(veiculos);
        }

        // GET: Veiculo/id
        public ActionResult Visualizar(int id)
        {
            var veiculo = Mapper.Map<VeiculoViewModel>(servicoVeiculos.ObterPorId(id));

            var parcial = Request["parcial"] == "s";
            ViewBag.parcial = parcial;

            if (parcial)
            {
                return PartialView(veiculo);
            }
            else
            {
                return View(veiculo);
            }
        }

        // GET: Veiculo/Incluir
        public ActionResult Incluir()
        {
            ViewBag.IdFabricante = ListaFabricantes();
            ViewBag.IdTipoDeVeiculo = ListaTipos();

            return View();
        }

        // POST: Veiculo/Incluir
        [HttpPost]
        public ActionResult Incluir(VeiculoViewModel veiculo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IdFabricante = ListaFabricantes(veiculo.IdFabricante);
                ViewBag.IdTipoDeVeiculo = ListaTipos(veiculo.IdTipoDeVeiculo);

                return View(veiculo);
            }

            var veiculoNovo = Mapper.Map<Veiculo>(veiculo);

            veiculoNovo.Fabricante = servicoFabricantes.ObterPorId(veiculo.IdFabricante);
            veiculoNovo.Tipo = servicoTipos.ObterPorId(veiculo.IdTipoDeVeiculo);

            servicoVeiculos.Incluir(veiculoNovo);

            return RedirectToAction("Index");
        }

        private SelectList ListaFabricantes(int? selecionado = null)
        {
            return new SelectList(servicoFabricantes.ObterTodos(), "Id", "Nome", selecionado.ToString());
        }

        private SelectList ListaTipos(int? selecionado = null)
        {
            return new SelectList(servicoTipos.ObterTodos(), "Id", "Nome", selecionado.ToString());
        }
    }
}