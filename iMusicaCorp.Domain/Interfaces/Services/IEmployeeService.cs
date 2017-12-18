using System;
using System.Collections.Generic;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Domain.Interfaces.Services
{
    public interface IEmployeeService : IServiceBase<Employee>
    {
        Employee GetById(Guid id);
        IEnumerable<Employee> GetGridData(string search, string order, int? limit, int? offset);
    }
}
