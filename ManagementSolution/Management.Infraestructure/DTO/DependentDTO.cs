using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Infraestructure.DTO
{
    [Table("Dependent", Schema = "dbo")]
    public class DependentDTO
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
        public char Gender { get; set; }
        public int EmployeeId { get; set; }

        public EmployeeDTO Employee { get; set; }
    }
}
