

using System;
using System.Collections.Generic;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Domain.Interfaces.ReadOnly
{
    public interface IEmployeeReadOnlyRepository
    {
        IEnumerable<Employee> GetGridData(string search, string order, int? limit, int? offset);
        Employee GetById(Guid id);
    }
}
