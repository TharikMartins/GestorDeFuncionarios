using Management.Infraestructure.DTO;
using Management.Infraestructure.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Management.Infraestructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private EnterpriseContext _enterpriseContext { get; set; }

        public EmployeeRepository(EnterpriseContext enterpriseContext)
        {
            this._enterpriseContext = enterpriseContext;
        }

        public List<EmployeeDTO> List()
        {
            var employees = _enterpriseContext.EmployeesDTO.Include(d => d.Dependents).ToList();

            return employees;
        }
        public void SaveEmployee(EmployeeDTO Employee)
        {
            this._enterpriseContext.Add(Employee);

            this._enterpriseContext.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = this._enterpriseContext.EmployeesDTO.Where(e => e.Id == employeeId).Include(d => d.Dependents).FirstOrDefault();

            if (employee != null)
                this._enterpriseContext.EmployeesDTO.Remove(employee);

            this._enterpriseContext.SaveChanges();
        }
        public EmployeeDTO FindEmployeeById(int employeeId)
        {
           return this._enterpriseContext.EmployeesDTO.Where(e => e.Id == employeeId).Include(d => d.Dependents).FirstOrDefault();
        }

        public void UpdateEmployee(EmployeeDTO EmployeeDTO)
        {
            this._enterpriseContext.Update(EmployeeDTO);

            this._enterpriseContext.SaveChanges();
        }

        public (List<EmployeeDTO> employeesDTO, List<DependentDTO> dependentsDTO) BirthdaysOfTheMonth()
        {
            var employeesDTO = this._enterpriseContext.EmployeesDTO.Where(e => e.Birthdate.Month == DateTime.Now.Month).ToList();
            var dependentsDTO = this._enterpriseContext.DependentsDTO.Where(d => d.Birthdate.Month == DateTime.Now.Month).ToList();
            return (employeesDTO, dependentsDTO);

        }
    }
}
