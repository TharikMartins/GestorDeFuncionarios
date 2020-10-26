using System.ComponentModel.DataAnnotations;

namespace Management.Models
{
    public class BirthdayOfTheMonthViewModel
    {
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Data de nascimento")]
        public string Birthdate { get; set; }

        [Display(Name = "Tipo de pessoa")]
        public string TypeOfPerson { get; set; }
    }
}
