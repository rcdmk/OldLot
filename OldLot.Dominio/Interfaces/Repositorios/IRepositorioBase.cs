using OldLot.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OldLot.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioBase<TEntity> : IDisposable where TEntity : class
    {
        TEntity ObterPorId(int id);
        ICollection<TEntity> ObterTodos();
        ICollection<TEntity> ObterLista(Expression<Func<TEntity, bool>> filtro);

        void Incluir(TEntity entidade);
        void Atualizar(TEntity entidade);
        void Excluir(TEntity entidade);
        void ExcluirPorId(int id);
    }
}
