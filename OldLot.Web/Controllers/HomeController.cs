using AutoMapper;
using OldLot.Aplicacao;
using OldLot.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OldLot.Web.Controllers
{
    public class HomeController : Controller
    {
        private ServicoAplicacaoVeiculo servico;

        public HomeController(ServicoAplicacaoVeiculo servico)
        {
            this.servico = servico;
        }

        public ActionResult Index()
        {
            var veiculos = Mapper.Map<IEnumerable<VeiculoViewModel>>(servico.ObterTodos());

            return View(veiculos);
        }
    }
}