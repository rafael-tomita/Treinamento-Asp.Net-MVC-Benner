using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.ServiceLocation;
using TreinamentoBenner.Core.Context;
using TreinamentoBenner.Core.Repository.Interfaces;

namespace TreinamentoBenner.Core.Repository.Common
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>, IDisposable where TEntity : class
    {
        private readonly TreinamentoBennerContext _context;
        private readonly IDbSet<TEntity> _dbSet;
        private DbContextTransaction _dbContextTransaction;

        protected RepositoryBase()
        {
            _context = ServiceLocator.Current.GetInstance<TreinamentoBennerContext>();
            _dbSet = _context.Set<TEntity>();
        }

        protected TreinamentoBennerContext Context => _context;
        protected IDbSet<TEntity> DbSet => _dbSet;


        public virtual void Save(TEntity entity)
        {
            DbSet.AddOrUpdate(entity);
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            var entry = Context.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = Find(id);
            Delete(entity);
        }

        public virtual TEntity Find(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<TEntity> All(bool @readonly = false)
        {
            return @readonly ? DbSet.AsNoTracking() : DbSet;
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return @readonly ? DbSet.Where(predicate).AsNoTracking() : DbSet.Where(predicate);
        }

        public void BeginTransaction()
        {
            _dbContextTransaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
            _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            _dbContextTransaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing) return;
            Context?.Dispose();
        }
    }
}
