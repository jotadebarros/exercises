using System;
using System.Collections.Generic;
using iMusicaCorp.Application.ViewModels;


namespace iMusicaCorp.Application.Interfaces
{
    public  interface IEmployeeAppService: IDisposable
    {
        EmployeeViewModel Add(EmployeeViewModel obj);
        EmployeeViewModel GetById(Guid id);
        IEnumerable<EmployeeViewModel> GetAll();
        void Update(EmployeeViewModel obj);
        void Remove(EmployeeViewModel obj);
        IEnumerable<EmployeeViewModel> GetGridData(string search, string order, int? limit, int? offset);
    }
}
