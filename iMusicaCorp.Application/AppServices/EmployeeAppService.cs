using AutoMapper;
using iMusicaCorp.Application.Interfaces;
using iMusicaCorp.Application.ViewModels;
using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace iMusicaCorp.Application.AppServices
{
    public class EmployeeAppService : AppService, IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeAppService(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        private static EmployeeViewModel EmployeeToViewModel(Employee employee)
        {
            return Mapper.Map<Employee, EmployeeViewModel>(employee);
        }

        private static Employee ViewModelToEmployee(EmployeeViewModel employeeViewModel)
        {
            return Mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
        }

        public EmployeeViewModel Add(EmployeeViewModel obj)
        {

            var employee = Mapper.Map<EmployeeViewModel, Employee>(obj);
           employee.EmployeeId = Guid.NewGuid();

            BeginTransaction();
            _employeeService.Add(employee);

            Commit();

            return obj;
            
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(_employeeService.GetAll());
        }

        public EmployeeViewModel GetById(Guid id)
        {
            return EmployeeToViewModel(_employeeService.GetById(id));
        }

        public void Remove(EmployeeViewModel obj)
        {
            var employee = ViewModelToEmployee(obj);

            BeginTransaction();
            _employeeService.Remove(employee);
            Commit();
        }

        public void Update(EmployeeViewModel obj)
        {
            var employee = Mapper.Map<EmployeeViewModel, Employee>(obj);
            
            BeginTransaction();
            _employeeService.Update(employee);
            Commit();
        }

        public void Dispose()
        {
            _employeeService.Dispose();
            GC.SuppressFinalize(this);

        }

        public IEnumerable<EmployeeViewModel> GetGridData(string search, string order, int? limit, int? offset)
        { 
            var data = _employeeService.GetGridData(search, order, limit, offset);

            return Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(data);
        }
    }
}
