using Management.Infraestructure.DTO;
using System.Collections.Generic;

namespace Management.Services.Employee.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> List();
        void Save(EmployeeDTO Employee);
        void Delete(int Id);
        EmployeeDTO FindById(int Id);
        void Update(EmployeeDTO Employee);
        (List<EmployeeDTO> Employees, List<DependentDTO> Dependents) GetBirthdayOfTheMonth();
    }
}
