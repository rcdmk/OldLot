using OldLot.Aplicacao.Interfaces;
using OldLot.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OldLot.Aplicacao
{
    public class ServicoAplicacaoBase<TEntity> : IServicoAplicacaoBase<TEntity> where TEntity : class
    {
        protected readonly IServicoBase<TEntity> servico;

        public ServicoAplicacaoBase(IServicoBase<TEntity> servico)
        {
            this.servico = servico;
        }

        public void Incluir(TEntity entidade)
        {
            servico.Incluir(entidade);
        }

        public void Atualizar(TEntity entidade)
        {
            servico.Atualizar(entidade);
        }

        public void Excluir(TEntity entidade)
        {
            servico.Excluir(entidade);
        }

        public void ExcluirPorId(int id)
        {
            servico.ExcluirPorId(id);
        }

        public TEntity ObterPorId(int id)
        {
            return servico.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return servico.ObterTodos();
        }

        public IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> filtro)
        {
            return servico.ObterLista(filtro);
        }

        public void Dispose()
        {
            servico.Dispose();
        }
    }
}
