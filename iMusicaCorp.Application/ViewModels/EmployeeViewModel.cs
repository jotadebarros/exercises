using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iMusicaCorp.Application.ViewModels
{
    public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            Dependents = new List<DependentViewModel>();
        }
        [Key]
        public Guid EmployeeId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        [MinLength(2, ErrorMessage = "Minimo {0} caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo Genero")]
        [DisplayName("Gênero")]
        public string Gender { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "Preencha o Data Nascimento")]
        //[DataType(DataType.Date)]
        public DateTime Birth { get; set; }

        [Required(ErrorMessage = "Preencha o campo Cargo")]
        [DisplayName("Cargo")]
        public int RoleId { get; set; }
        public virtual RoleViewModel Role { get; set; }


        public List<DependentViewModel> Dependents { get; set; }

        public int Rows { get; set; }

    }

    
}