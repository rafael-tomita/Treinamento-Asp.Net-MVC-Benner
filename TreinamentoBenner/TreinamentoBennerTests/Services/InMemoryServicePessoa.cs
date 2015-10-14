using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBennerTests.Services
{
    public class InMemoryServicePessoa : IServicePessoa
    {
        private readonly List<Pessoa> db;

        public InMemoryServicePessoa()
        {
            db = new List<Pessoa>();
        }

        public Pessoa Find(int id)
        {
            return db.FirstOrDefault(q => q.Id == id);
        }

        public IQueryable<Pessoa> All(bool @readonly = false)
        {
            return db.AsQueryable();
        }

        public IQueryable<Pessoa> Query(Expression<Func<Pessoa, bool>> predicate, bool @readonly = false)
        {
            return db.Where(predicate.Compile()).AsQueryable();
        }

        public void Save(Pessoa entity)
        {
            var pessoa = Find(entity.Id);
            if (pessoa != null)
                db.Remove(pessoa);

            db.Add(entity);
        }

        public void Create(Pessoa entity)
        {
        }

        public void Update(Pessoa entity)
        {
        }

        public void Delete(Pessoa entity)
        {
            db.Remove(entity);
        }

        public void Delete(int id)
        {
            Delete(Find(id));
        }
    }
}