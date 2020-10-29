using Management.Infraestructure.DTO;
using Management.Infraestructure.Repositories.Interface;
using Management.Services.Employee.Interfaces;
using System.Collections.Generic;

namespace Management.Services.Employee
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;

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
           this._employeeRepository.Save(employee);
        }

        public void Delete(int Id)
        {
            this._employeeRepository.Delete(Id);
        }

        public EmployeeDTO FindById(int Id)
        {
            return this._employeeRepository.FindById(Id);
        }

        public void Update(EmployeeDTO Employe)
        {
            this._employeeRepository.Update(Employe);
        }

        public (List<EmployeeDTO> Employees, List<DependentDTO> Dependents) GetBirthdayOfTheMonth()
        {
            return this._employeeRepository.BirthdaysOfTheMonth();
        }
    }
}
