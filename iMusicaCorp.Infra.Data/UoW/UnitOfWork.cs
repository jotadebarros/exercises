using iMusicaCorp.Infra.Data.Context;
using iMusicaCorp.Infra.Data.Interface;
using Microsoft.Practices.ServiceLocation;
using System;

namespace iMusicaCorp.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MusicaCorpContext _dbContext;
        private bool _disposed;

        public UnitOfWork()
        {
            var contextManager = ServiceLocator.Current.GetInstance<IContextManager>();
            _dbContext = contextManager.GetContext();
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

       
    }
}
