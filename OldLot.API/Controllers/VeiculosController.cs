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
        private IServicoAplicacaoVeiculo servicoVeiculos;
        private IServicoAplicacaoFabricante servicoFabricantes;
        private IServicoAplicacaoTipoDeVeiculo servicoTipos;

        public VeiculosController(IServicoAplicacaoVeiculo servicoVeiculos, IServicoAplicacaoFabricante servicoFabricantes, IServicoAplicacaoTipoDeVeiculo servicoTipos)
        {
            this.servicoVeiculos = servicoVeiculos;
            this.servicoFabricantes = servicoFabricantes;
            this.servicoTipos = servicoTipos;
        }

        // GET api/veiculos
        public IEnumerable<VeiculoModel> Get()
        {
            return Mapper.Map<IEnumerable<VeiculoModel>>(servicoVeiculos.ObterTodos());
        }

        // GET api/veiculos/5
        public IHttpActionResult Get(int id)
        {
            var veiculo = Mapper.Map<VeiculoModel>(servicoVeiculos.ObterPorId(id));

            if (veiculo == null) return NotFound();

            return Ok(veiculo);
        }

        // POST api/veiculos
        public IHttpActionResult Post(VeiculoModel veiculo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var veiculoParaIncluir = Mapper.Map<Veiculo>(veiculo);

            servicoVeiculos.Incluir(veiculoParaIncluir);

            return Ok();
        }

        // PUT api/veiculos/5
        public IHttpActionResult Put(int id, VeiculoModel veiculo)
        {
            if (!ModelState.IsValid) return BadRequest();

            var veiculoAlterado = servicoVeiculos.ObterPorId(id);

            if (veiculoAlterado == null) return NotFound();

            veiculoAlterado = Mapper.Map<VeiculoModel, Veiculo>(veiculo, veiculoAlterado);

            if (veiculoAlterado.Fabricante.Id != veiculo.Fabricante.id)
            {
                veiculoAlterado.Fabricante = servicoFabricantes.ObterPorId(veiculo.Fabricante.id);
            }

            if (veiculoAlterado.Tipo.Id != veiculo.Tipo.id)
            {
                veiculoAlterado.Tipo = servicoTipos.ObterPorId(veiculo.Tipo.id);
            }

            servicoVeiculos.Atualizar(veiculoAlterado);

            return Ok();
        }

        // DELETE api/veiculos/5
        public IHttpActionResult Delete(int id)
        {
            var veiculoParaExcluir = servicoVeiculos.ObterPorId(id);

            if (veiculoParaExcluir == null) return NotFound();

            servicoVeiculos.ExcluirPorId(id);

            return Ok();
        }
    }
}
