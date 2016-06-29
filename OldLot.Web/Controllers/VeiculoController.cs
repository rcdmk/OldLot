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
            ViewBag.IdFabricante = MontarListaFabricantes();
            ViewBag.IdTipoDeVeiculo = MontarListaTiposDeVeiculo();

            return View();
        }

        // POST: Veiculo/Incluir
        [HttpPost]
        public ActionResult Incluir(VeiculoViewModel veiculo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IdFabricante = MontarListaFabricantes(veiculo.IdFabricante);
                ViewBag.IdTipoDeVeiculo = MontarListaTiposDeVeiculo(veiculo.IdTipoDeVeiculo);

                return View(veiculo);
            }

            var veiculoNovo = Mapper.Map<Veiculo>(veiculo);

            veiculoNovo.Fabricante = servicoFabricantes.ObterPorId(veiculo.IdFabricante);
            veiculoNovo.Tipo = servicoTipos.ObterPorId(veiculo.IdTipoDeVeiculo);

            servicoVeiculos.Incluir(veiculoNovo);

            TempData["sucesso"] = "Incluído com sucesso!";
            return RedirectToAction("Index");
        }

        // GET: Veiculo/Alterar/id
        public ActionResult Alterar(int id)
        {
            var veiculo = Mapper.Map<VeiculoViewModel>(servicoVeiculos.ObterPorId(id));

            if (veiculo == null) return HttpNotFound();

            ViewBag.IdFabricante = MontarListaFabricantes(veiculo.IdFabricante);
            ViewBag.IdTipoDeVeiculo = MontarListaTiposDeVeiculo(veiculo.IdTipoDeVeiculo);

            return View(veiculo);
        }

        // POST: Veiculo/Alterar/id
        [HttpPost]
        public ActionResult Alterar(int id, VeiculoViewModel veiculo)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.IdFabricante = MontarListaFabricantes(veiculo.IdFabricante);
                ViewBag.IdTipoDeVeiculo = MontarListaTiposDeVeiculo(veiculo.IdTipoDeVeiculo);

                return View(veiculo);
            }

            var veiculoAlterado = servicoVeiculos.ObterPorId(id);

            if (veiculoAlterado == null) return HttpNotFound();

            veiculoAlterado = Mapper.Map<VeiculoViewModel, Veiculo>(veiculo, veiculoAlterado);

            if (veiculoAlterado.Fabricante.Id != veiculo.IdFabricante)
            {
                veiculoAlterado.Fabricante = servicoFabricantes.ObterPorId(veiculo.IdFabricante);
            }

            if (veiculoAlterado.Tipo.Id != veiculo.IdTipoDeVeiculo)
            {
                veiculoAlterado.Tipo = servicoTipos.ObterPorId(veiculo.IdTipoDeVeiculo);
            }

            servicoVeiculos.Atualizar(veiculoAlterado);

            TempData["sucesso"] = "Alterado com sucesso!";
            return RedirectToAction("Index");
        }


        // GET: Veiculo/Excluir/id
        public ActionResult Excluir(int id)
        {
            servicoVeiculos.ExcluirPorId(id);

            TempData["sucesso"] = "Excluído com sucesso!";
            return RedirectToAction("Index");
        }

        #region Utils

        private SelectList MontarListaFabricantes(int? selecionado = null)
        {
            return new SelectList(servicoFabricantes.ObterTodos(), "Id", "Nome", selecionado.ToString());
        }

        private SelectList MontarListaTiposDeVeiculo(int? selecionado = null)
        {
            return new SelectList(servicoTipos.ObterTodos(), "Id", "Nome", selecionado.ToString());
        }

        #endregion
    }
}