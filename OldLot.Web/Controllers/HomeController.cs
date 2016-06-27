using OldLot.Aplicacao;
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
            return View();
        }
    }
}