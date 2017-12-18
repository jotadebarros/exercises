using iMusicaCorp.Infra.Data.Interface;
using Microsoft.Practices.ServiceLocation;

namespace iMusicaCorp.Application.AppServices
{
    public class AppService
    {
        private IUnitOfWork _uow;
        public void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork>();
            _uow.BeginTransaction();
        }

        public void Commit()
        {
            _uow.SaveChanges();
        }
    }
}
