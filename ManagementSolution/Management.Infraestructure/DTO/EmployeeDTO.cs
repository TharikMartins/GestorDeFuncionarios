using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Infraestructure.DTO
{
    [Table("Employee",Schema = "dbo")]
    public class EmployeeDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime Birthdate { get; set; }
        public string Phone { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public ICollection<DependentDTO> Dependents { get; set; }
    }
}
