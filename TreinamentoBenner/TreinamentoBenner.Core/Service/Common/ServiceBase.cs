using System;
using System.Linq;
using System.Linq.Expressions;
using TreinamentoBenner.Core.Repository.Interfaces;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBenner.Core.Service.Common
{
    public class ServiceBase<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public ServiceBase(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public TEntity Find(int id)
        {
            return _repository.Find(id);
        }

        public IQueryable<TEntity> All(bool @readonly = false)
        {
            return _repository.All(@readonly);
        }

        public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>> predicate, bool @readonly = false)
        {
            return _repository.Query(predicate, @readonly);
        }

        public void Save(TEntity entity)
        {
            _repository.BeginTransaction();
            _repository.Save(entity);
            _repository.Commit();
        }

        public void Create(TEntity entity)
        {
            _repository.BeginTransaction();
            _repository.Add(entity);
            _repository.Commit();
        }

        public void Update(TEntity entity)
        {
            _repository.BeginTransaction();
            _repository.Update(entity);
            _repository.Commit();
        }

        public void Delete(TEntity entity)
        {
            _repository.BeginTransaction();
            _repository.Delete(entity);
            _repository.Commit();
        }

        public void Delete(int id)
        {
            Delete(Find(id));
        }
    }
}
