using Management.Infraestructure.DTO;
using Management.Infraestructure.Repositories.Interface;
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
            var employees = _enterpriseContext.EmployeesDTO.ToList();

            foreach (var employee in employees)
            {
                var dependents = _enterpriseContext.DependentsDTO.ToList();
                employee.Dependents = dependents != null && dependents.Count > 0 ? dependents.Where(d => d.EmployeeId == employee.Id).ToList()
                    : new List<DependentDTO>();
            }

            return employees;
        }
        public int SaveEmployee(EmployeeDTO Employee)
        {
            this._enterpriseContext.Add(Employee);

            return this._enterpriseContext.SaveChanges();
        }

        public void SaveDependent(DependentDTO Dependent)
        {
            this._enterpriseContext.Add(Dependent);

            this._enterpriseContext.SaveChanges();
        }

        public void DeleteEmployee(int employeeId)
        {
            var employee = this._enterpriseContext.EmployeesDTO.Where(e => e.Id == employeeId).FirstOrDefault();

            DeleteDependent(employee.Id);

            if (employee != null)
                this._enterpriseContext.EmployeesDTO.Remove(employee);

            this._enterpriseContext.SaveChanges();
        }

        public void DeleteDependent(int employeeId)
        {
            var dependent = this._enterpriseContext.DependentsDTO.Where(d => d.EmployeeId == employeeId).ToList();

            if (dependent != null && dependent.Count > 0)
            {
                dependent.ForEach(d =>
                {
                    this._enterpriseContext.DependentsDTO.Remove(d);
                });

                this._enterpriseContext.SaveChanges();
            }
        }

        public EmployeeDTO FindEmployeeById(int employeeId)
        {
            var employee = this._enterpriseContext.EmployeesDTO.Where(e => e.Id == employeeId).FirstOrDefault();
            var dependents = this._enterpriseContext.DependentsDTO.Where(d => d.EmployeeId == employeeId).ToList();

            if (dependents != null && dependents.Count > 0)
                employee.Dependents = dependents;

            return employee;
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
