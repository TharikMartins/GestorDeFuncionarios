using Management.Infraestructure.DTO;
using System.Collections.Generic;

namespace Management.Infraestructure.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> List();
        void SaveEmployee(EmployeeDTO Employee);
        void DeleteEmployee(int EmployeeId);
        EmployeeDTO FindEmployeeById(int EmployeeId);
        void UpdateEmployee(EmployeeDTO EmployeeDTO);
        (List<EmployeeDTO> employeesDTO, List<DependentDTO> dependentsDTO) BirthdaysOfTheMonth();
    }
}
