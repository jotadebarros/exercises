  
using System;

namespace iMusicaCorp.Domain.Entities
{
    public class Dependent
    {
        public int DependentId { get; set; }
        public string Name { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual  Employee Employee { get; set; }
        public bool Excluido { get; set; }
    }
}
