using Dapper;
using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Domain.Interfaces.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace iMusicaCorp.Infra.Data.Repositories.ReadOnly
{
   public  class DependentReadOnlyRepositoryRepository : RepositoryBaseReadOnly, IDependentReadOnlyRepository

    {
        public IEnumerable<Dependent> GetDependentsEmployee(Guid emid)
        {
            using (IDbConnection cn = Connection)
            {
                var query = string.Format(@"SELECT
                                 dp.DependentId
								,dp.EmployeeId
							    ,dp.Name
                            FROM
                                Dependent dp
                            WHERE dp.EmployeeId = '{0}'", emid);


                var deps = cn.Query<Dependent>(query);

                cn.Close();

                return deps.ToList();
            }
        }
    }
}
