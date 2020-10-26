using Management.Infraestructure.DTO;
using Management.Infraestructure.Repositories.Interface;
using Management.Services.Employee.Interfaces;
using System.Collections.Generic;

namespace Management.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository { get; set; }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        public List<EmployeeDTO> List()
        {
            return this._employeeRepository.List();
        }

        public void Save(EmployeeDTO employee)
        {
            var employmeeId = this._employeeRepository.SaveEmployee(employee);

            //SaveDependents(employee.Dependents, employmeeId);
        }

        private void SaveDependents(ICollection<DependentDTO> Dependents, int employeeId)
        {
            if (Dependents != null && Dependents.Count > 0)
            {
                foreach (var dependent in Dependents)
                {
                    dependent.EmployeeId = employeeId;
                    this._employeeRepository.SaveDependent(dependent);
                }
            }

        }

        public void Delete(int employeeId)
        {
            this._employeeRepository.DeleteEmployee(employeeId);
        }

        public EmployeeDTO FindEmployeeById(int employeeId)
        {
            return this._employeeRepository.FindEmployeeById(employeeId);
        }

        public void UpdateEmployee(EmployeeDTO EmployeeDTO)
        {
            this._employeeRepository.UpdateEmployee(EmployeeDTO);
        }

        public (List<EmployeeDTO> Employees, List<DependentDTO> Dependents) GetBirthdayOfTheMonth()
        {
            return this._employeeRepository.BirthdaysOfTheMonth();
        }
    }
}
