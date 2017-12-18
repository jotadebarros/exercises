using Dapper;
using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Domain.Interfaces.ReadOnly;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace iMusicaCorp.Infra.Data.Repositories.ReadOnly
{
    public class EmployeeReadOnlyRepository : RepositoryBaseReadOnly, IEmployeeReadOnlyRepository
    {
        public Employee GetById(Guid id)
        {
            using (IDbConnection cn = Connection)
            {
                var sql = string.Format(@"SELECT                                            

                                                     	EMY.EmployeeId
                                                         ,EMY.Name
                                                            ,EMY.Email
                                                            ,EMY.Gender
                                                            ,EMY.Birth
                                                            ,EMY.RoleId
                					,rl.RoleId
                					,rl.Name													
                                                        FROM
                                                         Employee EMY

                					inner join Role RL
                					on emy.RoleId = RL.RoleId													
                                                    where EMY.EmployeeId ='{0}'", id);


                cn.Open();


                var retorno = cn.Query<Employee, Role, Employee>(sql,
                    (e, r) =>
                    {
                        e.RoleId = r.RoleId;
                        e.Role = r;

                        return e;
                    }, splitOn: "EmployeeId,RoleId").SingleOrDefault();
                cn.Close();

                if (retorno != null)
                {
                    var repDependent = new DependentReadOnlyRepositoryRepository();
                    retorno.Dependents.AddRange(repDependent.GetDependentsEmployee(retorno.EmployeeId));
                }




                return retorno;
            }
        }

        public IEnumerable<Employee> GetGridData(string search, string order, int? limit, int? offset)
        {
            using (IDbConnection cn = Connection)
            {
                var where = !string.IsNullOrEmpty(search)
                    ? string.Format(@"WHERE ((EMY.Name LIKE '%{0}%')
                			                                                    OR (EMY.Email  LIKE '%{0}%')
                                                                                OR (EMY.Gender  LIKE '%{0}%')                                                                                
                                                                                OR (EMY.Birth  LIKE '%{0}%'))", search)
                    : null;

                string pag = "";

                if (limit != null && offset != null)
                {
                    pag = string.Format("OFFSET {0} ROWS FETCH NEXT {1} ROWS ONLY", offset.Value, limit.Value);
                }


                var queryCount = string.Format(@"SELECT
                                                       COUNT(1)
                                                    FROM
                                                       Employee emy
                                                    {0}", !string.IsNullOrEmpty(where) ? where : "");

                var sql = string.Format(@"DECLARE @COUNT int;
                                          SET @COUNT = ({0})

                                            SELECT	                                             
                                                @COUNT AS Rows
	                                            	,EMY.EmployeeId
	                                                ,EMY.Name
                                                    ,EMY.Email
                                                    ,EMY.Gender
                                                    ,EMY.Birth
                                                    ,EMY.RoleId
													,rl.RoleId
													,rl.Name													
                                                FROM
	                                                Employee EMY

													inner join Role RL
													on emy.RoleId = RL.RoleId													
                                            {1}
                                            ORDER BY
	                                              EMY.Name {2}
                                            {3}"
                    , queryCount
                    , !string.IsNullOrEmpty(where) ? where : ""
                    , order
                    , pag);


                cn.Open();


                var retorno = cn.Query<Employee, Role, Employee>(sql,
                    (e, r) =>
                    {
                        e.RoleId = r.RoleId;
                        e.Role = r;

                        return e;
                    }, splitOn: "EmployeeId,RoleId").ToList();


                var repDependent = new DependentReadOnlyRepositoryRepository();
                foreach (var employee in retorno)
                {
                    employee.Dependents.AddRange(repDependent.GetDependentsEmployee(employee.EmployeeId));
                }

                cn.Close();


                return retorno;
            }
        }
    }
}
