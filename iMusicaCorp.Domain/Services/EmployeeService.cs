using iMusicaCorp.Domain.Entities;
using iMusicaCorp.Domain.Interfaces.ReadOnly;
using iMusicaCorp.Domain.Interfaces.Repositories;
using iMusicaCorp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;


namespace iMusicaCorp.Domain.Services
{
    public class EmployeeService : ServiceBase<Employee>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeReadOnlyRepository _employeeReadOnlyRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeReadOnlyRepository employeeReadOnlyRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeReadOnlyRepository = employeeReadOnlyRepository;
        }

        public Employee GetById(Guid id)
        {
           return _employeeReadOnlyRepository.GetById(id);
        }

        public IEnumerable<Employee> GetGridData(string search, string order, int? limit, int? offset)
        {
            return _employeeReadOnlyRepository.GetGridData(search, order, limit, offset);
        }

        public override void Remove(Employee obj)
        {
            _employeeRepository.Remove(obj);
        }

        public override void Update(Employee obj)
        {
            _employeeRepository.Update(obj);
        }
    }
}
