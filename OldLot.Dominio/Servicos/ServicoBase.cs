using OldLot.Dominio.Interfaces.Repositorios;
using OldLot.Dominio.Interfaces.Servicos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OldLot.Dominio.Servicos
{
    public class ServicoBase<TEntity> : IDisposable, IServicoBase<TEntity> where TEntity : class
    {
        protected readonly IRepositorioBase<TEntity> repositorio;

        public ServicoBase(IRepositorioBase<TEntity> repositorio)
        {
            this.repositorio = repositorio;
        }

        public void Incluir(TEntity entidade)
        {
            repositorio.Incluir(entidade);
        }

        public void Atualizar(TEntity entidade)
        {
            repositorio.Atualizar(entidade);
        }

        public void Excluir(TEntity entidade)
        {
            repositorio.Excluir(entidade);
        }

        public void ExcluirPorId(int id)
        {
            repositorio.ExcluirPorId(id);
        }

        public TEntity ObterPorId(int id)
        {
            return repositorio.ObterPorId(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return repositorio.ObterTodos();
        }

        public IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> filtro)
        {
            return repositorio.ObterLista(filtro);
        }

        public void Dispose()
        {
            repositorio.Dispose();
        }
    }
}
