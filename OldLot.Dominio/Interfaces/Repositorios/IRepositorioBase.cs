using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace OldLot.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> : IDisposable where TEntity : class
    {
        TEntity ObterPorId(int id);
        IEnumerable<TEntity> ObterTodos();
        IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> filtro);

        void Incluir(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Excluir(TEntity entidade);
        void ExcluirPorId(int id);
    }
}
