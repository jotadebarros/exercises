using iMusicaCorp.Domain.Interfaces.Repositories;
using iMusicaCorp.Infra.Data.Context;
using iMusicaCorp.Infra.Data.Interface;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace iMusicaCorp.Infra.Data.Repositories.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected MusicaCorpContext Db;
        protected DbSet<TEntity> DbSet;


        public RepositoryBase()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager>();
            Db = contextManager.GetContext();
            DbSet = Db.Set<TEntity>();
        }

        public void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual  void Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
