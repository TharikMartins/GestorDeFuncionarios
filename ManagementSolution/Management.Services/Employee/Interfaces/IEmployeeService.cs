using Management.Infraestructure.DTO;
using System.Collections.Generic;

namespace Management.Services.Employee.Interfaces
{
    public interface IEmployeeService
    {
        List<EmployeeDTO> List();
        void Save(EmployeeDTO Employee);
        void Delete(int employeeId);
        EmployeeDTO FindEmployeeById(int employeeId);
        void UpdateEmployee(EmployeeDTO EmployeeDTO);
        (List<EmployeeDTO> Employees, List<DependentDTO> Dependents) GetBirthdayOfTheMonth();
    }
}
