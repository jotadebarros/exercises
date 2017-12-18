using System;

namespace iMusicaCorp.Application.ViewModels
{
    public class DependentViewModel
    {
        public int DependentId { get; set; }
        public string Name { get; set; }
        public Guid EmployeeId { get; set; }
        public virtual EmployeeViewModel Employee { get; set; }

        public bool Excluido { get; set; }
    }
}
