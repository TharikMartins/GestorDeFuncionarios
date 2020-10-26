using Management.Infraestructure.DTO;
using System.Collections.Generic;

namespace Management.Infraestructure.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        List<EmployeeDTO> List();
        int SaveEmployee(EmployeeDTO Employee);
        void SaveDependent(DependentDTO Dependent);
        void DeleteEmployee(int EmployeeId);
        EmployeeDTO FindEmployeeById(int EmployeeId);
        void UpdateEmployee(EmployeeDTO EmployeeDTO);
        (List<EmployeeDTO> employeesDTO, List<DependentDTO> dependentsDTO) BirthdaysOfTheMonth();
    }
}
