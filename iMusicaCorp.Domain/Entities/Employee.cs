using System;
using System.Collections.Generic;

namespace iMusicaCorp.Domain.Entities
{
    public class Employee
    {
        public Employee()
        {
            Dependents = new List<Dependent>();
        }
        public Guid EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime Birth { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual List<Dependent> Dependents { get; set; }

        public int Rows { get; set; }
        

    }
}
