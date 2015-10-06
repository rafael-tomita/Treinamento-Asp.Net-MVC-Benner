using System;
using System.Linq;
using System.Linq.Expressions;

namespace TreinamentoBenner.Core.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entity);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
        TEntity Find(int id);
        IQueryable<TEntity> All(bool @readonly = false);
        IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false);

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}

