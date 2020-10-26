using Management.Infraestructure.DTO;
using Management.Models;
using System;
using System.Collections.Generic;

namespace Management.Parse
{
    public class ParseDTO
    {

        public static List<EmployeeViewModel> ParseEmployee(List<EmployeeDTO> employeesDTO)
        {
            var employeesViewModel = new List<EmployeeViewModel>();

            if (employeesDTO.Count > 0)
            {
                employeesDTO.ForEach(e =>
                {
                    employeesViewModel.Add(
                        new EmployeeViewModel
                        {
                            Id = e.Id,
                            Name = e.Name,
                            Address = e.Address,
                            Birthdate = e.Birthdate.ToString("dd/MM/yyyy"),
                            Gender = e.Gender == 'M' ? "Masculino" : "Feminino",
                            CPF = e.CPF,
                            Phone = e.Phone,
                            IsActive = e.IsActive,
                            Dependent = ParseDependent(e.Dependents)
                        });
                });
            }

            return employeesViewModel;
        }

        public static List<BirthdayOfTheMonthViewModel> ParseBirthdayList((List<EmployeeDTO> Employees, List<DependentDTO> Dependents) birthdayList)
        {
            var birthdayViewModelList = new List<BirthdayOfTheMonthViewModel>();

            birthdayList.Employees.ForEach(e =>
            {
                birthdayViewModelList.Add(new BirthdayOfTheMonthViewModel()
                {
                    Name = e.Name,
                    Birthdate = e.Birthdate.ToString("dd/MM/yyyy"),
                    TypeOfPerson = "Funcionário"
                });
            });

            birthdayList.Dependents.ForEach(d =>
            {
                birthdayViewModelList.Add(new BirthdayOfTheMonthViewModel()
                {
                    Name = d.Name,
                    Birthdate = d.Birthdate.ToString("dd/MM/yyyy"),
                    TypeOfPerson = "Dependente"
                });
            });

            return birthdayViewModelList;
        }

        public static List<DependentViewModel> ParseDependent(ICollection<DependentDTO> dependentsDTO)
        {
            var dependentViewModel = new List<DependentViewModel>();

            if (dependentsDTO != null && dependentsDTO.Count > 0)
            {
                foreach (var d in dependentsDTO)
                {
                    dependentViewModel.Add(new DependentViewModel
                    {
                        Id = d.Id,
                        Name = d.Name,
                        Birthdate = d.Birthdate.ToString("dd/MM/yyyy"),
                        Gender = d.Gender,
                        EmployeeId = d.EmployeeId
                    });
                }
            }
            return dependentViewModel;
        }

        public static EmployeeDTO ParseEmployee(EmployeeViewModel employeeViewModel)
        {

            return new EmployeeDTO
            {
                Id = employeeViewModel.Id,
                Name = employeeViewModel.Name,
                Address = $"{employeeViewModel.Address} - {employeeViewModel.AddressNumber}",
                Birthdate = Convert.ToDateTime(employeeViewModel.Birthdate),
                Gender = Convert.ToChar(employeeViewModel.Gender),
                CPF = employeeViewModel.CPF,
                Phone = employeeViewModel.Phone,
                IsActive = employeeViewModel.IsActive,
                Dependents = ParseDependent(employeeViewModel.Dependent)
            };
        }

        public static List<DependentDTO> ParseDependent(List<DependentViewModel> dependentViewModel)
        {
            var dependentDTO = new List<DependentDTO>();

            if (dependentViewModel != null && dependentViewModel.Count > 0)
            {
                dependentViewModel.ForEach(d =>
                {
                    dependentDTO.Add(new DependentDTO
                    {
                        Name = d.Name,
                        Birthdate = Convert.ToDateTime(d.Birthdate),
                        Gender = d.Gender,
                    });
                });
            }

            return dependentDTO;
        }

        public static EmployeeViewModel ParseEmployee(EmployeeDTO employeesDTO)
        {
            var employeesViewModel = new EmployeeViewModel();

            if (employeesDTO != null)
            {

                employeesViewModel.Id = employeesDTO.Id;
                employeesViewModel.Name = employeesDTO.Name;
                employeesViewModel.Address = employeesDTO.Address;
                employeesViewModel.Birthdate = employeesDTO.Birthdate.ToString("dd/MM/yyyy");
                employeesViewModel.Gender = employeesDTO.Gender == 'M' ? "Masculino" : "Feminino";
                employeesViewModel.CPF = employeesDTO.CPF;
                employeesViewModel.Phone = employeesDTO.Phone;
                employeesViewModel.IsActive = employeesDTO.IsActive;
                employeesViewModel.Dependent = ParseDependent(employeesDTO.Dependents);

            }

            return employeesViewModel;
        }
    }
}
