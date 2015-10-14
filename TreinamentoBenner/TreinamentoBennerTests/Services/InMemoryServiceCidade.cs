using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TreinamentoBenner.Core.Model;
using TreinamentoBenner.Core.Service.Interfaces;

namespace TreinamentoBennerTests.Services
{
    public class InMemoryServiceCidade : IServiceCidade
    {
        private readonly List<Cidade> db;

        public InMemoryServiceCidade()
        {
            db = new List<Cidade>();
        }

        public Cidade Find(int id)
        {
            return db.FirstOrDefault(q => q.Id == id);
        }

        public IQueryable<Cidade> All(bool @readonly = false)
        {
            return db.AsQueryable();
        }

        public IQueryable<Cidade> Query(Expression<Func<Cidade, bool>> predicate, bool @readonly = false)
        {
            return db.Where(predicate.Compile()).AsQueryable();
        }

        public void Save(Cidade entity)
        {
            var cidade = Find(entity.Id);
            if (cidade != null)
                db.Remove(cidade);

            db.Add(entity);
        }

        public void Create(Cidade entity)
        {
        }

        public void Update(Cidade entity)
        {
        }

        public void Delete(Cidade entity)
        {
            db.Remove(entity);
        }

        public void Delete(int id)
        {
            Delete(Find(id));
        }

        public IEnumerable<string> ListarEstados()
        {
            return db.GroupBy(q => q.Uf).Select(q => q.Key);
        }
    }
}