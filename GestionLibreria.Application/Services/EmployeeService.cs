using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.Services
{
        public class EmployeeService : IEmployeeService
        {
            private readonly IEmployeeRepository _employeeRepository;

            public EmployeeService(IEmployeeRepository employeeRepository   )
            {
                this._employeeRepository = employeeRepository;
            }

            public EmployeeResponse AddEmployee(CreateEmployeeRequest request)
            {
                var employee = new Employee(request.Dni, request.Name, request.LastName, request.Mail, request.PassWordHash, request.Address, request.Phone, request.Salary, request.Shift, request.HireDate, request.Role);

                _employeeRepository.AddEmployee(employee);

                return EmployeeResponse.FromEmployee(employee);
            }

            public IReadOnlyList<EmployeeResponse> GetAllEmployees()
            {
                var employees = _employeeRepository.GetAllEmployees();
                return employees.Select(EmployeeResponse.FromEmployee).ToList();
            }

            public EmployeeResponse? GetEmployeeById(Guid id)
            {
                var employee = _employeeRepository.GetEmployeeById(id);
                return employee != null ? EmployeeResponse.FromEmployee(employee) : null;
            }

            public void RemoveEmployee(Guid id)
            {
                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    return;
                }

                _employeeRepository.RemoveEmployee(employee);
            }

            public bool UpdateEmployeeContact(Guid id, UpdateEmployeeContactRequest request)
            {
                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    return false;
                }

                employee.UpdateProfile(request.Mail, request.PassWordHash, request.Address, request.Phone);

                _employeeRepository.UpdateEmployeeContact(employee);

                return true;
            }

            public bool UpdateEmployeeDetails(Guid id, UpdateEmployeeDetailsRequest request)
            {
                var employee = _employeeRepository.GetEmployeeById(id);

                if (employee == null)
                {
                    return false;
                }

                employee.UpdateEmployeeDetails(request.Salary ?? employee.Salary, request.Shift ?? employee.Shift, request.Role ?? employee.Role);

                _employeeRepository.UpdateEmployeeDetails(employee);

                return true;
            }
        }
}

