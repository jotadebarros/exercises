using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Domain.Interfaces.Repositories;
using System.Data.Entity;
using System.Linq;

namespace iMusicaCorp.Infra.Data.Repositories.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {


        public override void Remove(Employee obj)
        {
            Db.Employees.Attach(obj);
            Db.Employees.Remove(obj);


        }


        public override void Update(Employee obj)
        {
            foreach (var dependent in obj.Dependents)
            {
                if (dependent.DependentId == 0)
                {
                    Db.Entry(dependent).State = EntityState.Added;
                }
                else
                {
                    Db.Entry(dependent).State = EntityState.Modified;
                }
            }

            Db.Dependents.RemoveRange(obj.Dependents.Where(x => x.Excluido));

            Db.Entry(obj).State = EntityState.Modified;
        }
    }
}
