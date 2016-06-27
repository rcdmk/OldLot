using OldLot.Dados.Contextos;
using OldLot.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace OldLot.Dados.Repositorios
{
    public class RepositorioBase<TEntity> : IRepositorioBase<TEntity> where TEntity : class
    {
        protected ContextoOldLot Db;
        protected DbSet<TEntity> Colecao;

        public RepositorioBase(ContextoOldLot dbContext)
        {
            this.Db = dbContext;
            this.Colecao = dbContext.Set<TEntity>();
        }

        public void Atualizar(TEntity entidade)
        {
            Db.Entry(entidade).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public void Excluir(TEntity entidade)
        {
            Colecao.Remove(entidade);
            Db.SaveChanges();
        }

        public void ExcluirPorId(int id)
        {
            var entidade = Colecao.Find(id);
            if (entidade != null)
            {
                Colecao.Remove(entidade);
                Db.SaveChanges();
            }
        }

        public void Incluir(TEntity entidade)
        {
            Colecao.Add(entidade);
            Db.SaveChanges();
        }

        public IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> filtro)
        {
            return Colecao.Where(filtro).ToList();
        }

        public TEntity ObterPorId(int id)
        {
            return Colecao.Find(id);
        }

        public IEnumerable<TEntity> ObterTodos()
        {
            return Colecao.ToList();
        }
    }
}
