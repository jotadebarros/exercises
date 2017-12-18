using System;
using System.Collections.Generic;
using iMusicaCorp.Domain.Entities;

namespace iMusicaCorp.Domain.Interfaces.ReadOnly
{
    public interface IDependentReadOnlyRepository
    {
        IEnumerable<Dependent> GetDependentsEmployee(Guid emid);
    }
}
