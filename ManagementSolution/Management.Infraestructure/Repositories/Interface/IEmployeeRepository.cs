using Management.Infraestructure.DTO;
using System.Collections.Generic;

namespace Management.Infraestructure.Repositories.Interface
{
    public interface IEmployeeRepository : IRepository<EmployeeDTO>
    {
        void Delete(int Id);
        (List<EmployeeDTO> employeesDTO, List<DependentDTO> dependentsDTO) BirthdaysOfTheMonth();
    }
}
