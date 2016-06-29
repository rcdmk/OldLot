using AutoMapper;
using OldLot.API.Models;
using OldLot.Aplicacao.Interfaces;
using OldLot.Dominio.Entidades;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;

namespace OldLot.API.Controllers
{
    public class VeiculosController : ApiController
    {
        private IServicoAplicacaoVeiculo servicoVeiculo;

        public VeiculosController(IServicoAplicacaoVeiculo servicoVeiculo)
        {
            this.servicoVeiculo = servicoVeiculo;
        }

        // GET api/veiculos
        public IEnumerable<VeiculoModel> Get()
        {
            return Mapper.Map<IEnumerable<VeiculoModel>>(servicoVeiculo.ObterTodos());
        }

        // GET api/veiculos/5
        public VeiculoModel Get(int id)
        {
            var veiculo = Mapper.Map<VeiculoModel>(servicoVeiculo.ObterPorId(id));

            if (veiculo != null) throw new HttpResponseException(HttpStatusCode.NotFound);

            return veiculo;
        }

        // POST api/veiculos
        public void Post(VeiculoModel veiculo)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var veiculoParaIncluir = Mapper.Map<Veiculo>(veiculo);

            servicoVeiculo.Incluir(veiculoParaIncluir);
        }

        // PUT api/veiculos/5
        public void Put(int id, VeiculoModel veiculo)
        {
            if (!ModelState.IsValid) throw new HttpResponseException(HttpStatusCode.BadRequest);

            var veiculoParaAlterar = servicoVeiculo.ObterPorId(id);

            if (veiculoParaAlterar != null) throw new HttpResponseException(HttpStatusCode.NotFound);

            veiculoParaAlterar = Mapper.Map(veiculo, veiculoParaAlterar);

            servicoVeiculo.Atualizar(veiculoParaAlterar);
        }

        // DELETE api/veiculos/5
        public void Delete(int id)
        {
            var veiculoParaExcluir = servicoVeiculo.ObterPorId(id);

            if (veiculoParaExcluir == null) throw new HttpResponseException(HttpStatusCode.NotFound);

            servicoVeiculo.ExcluirPorId(id);
        }
    }
}
