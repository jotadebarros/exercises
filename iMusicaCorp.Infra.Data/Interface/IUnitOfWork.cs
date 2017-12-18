namespace iMusicaCorp.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
