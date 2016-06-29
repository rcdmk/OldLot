using OldLot.Dados.Contextos;
using OldLot.Dominio.Interfaces.Repositorios;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

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

        public virtual void Atualizar(TEntity entidade)
        {
            if (Db.Entry(entidade).State == EntityState.Detached) Colecao.Attach(entidade);
            Db.Entry(entidade).State = EntityState.Modified;
            Db.SaveChanges();
        }

        public virtual void Dispose()
        {
            Db.Dispose();
        }

        public virtual void Excluir(TEntity entidade)
        {
            Colecao.Remove(entidade);
            Db.SaveChanges();
        }

        public virtual void ExcluirPorId(int id)
        {
            var entidade = Colecao.Find(id);
            if (entidade != null)
            {
                Colecao.Remove(entidade);
                Db.SaveChanges();
            }
        }

        public virtual void Incluir(TEntity entidade)
        {
            Colecao.Add(entidade);
            Db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> ObterLista(Expression<Func<TEntity, bool>> filtro)
        {
            return Colecao.Where(filtro).ToList();
        }

        public virtual TEntity ObterPorId(int id)
        {
            return Colecao.Find(id);
        }

        public virtual IEnumerable<TEntity> ObterTodos()
        {
            return Colecao.ToList();
        }
    }
}
