using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [Display(Name = "Data de nascimento")]
        public string Birthdate { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [Display(Name = "Telefone")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Selecione o campo")]
        [Display(Name = "Genêro")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Preencha o campo")]
        [Display(Name = "Número")]
        public int AddressNumber { get; set; }

        [Required(ErrorMessage = "Selecione o campo")]
        [Display(Name = "Ativo")]
        public bool IsActive { get; set; }

        public List<DependentViewModel> Dependent { get; set; }
    }
}
