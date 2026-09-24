using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.Interfaces
{
    public interface IEmployeeService
    {
        Employee AddEmployee(CreateEmployeeRequest request);

        IReadOnlyList<Employee> GetAllEmployees();

        Employee? GetEmployeeById(Guid id);

        void RemoveEmployee(Guid id);

        bool UpdateEmployeeContact(Guid id, UpdateEmployeeContactRequest request);

        bool UpdateEmployeeDetails(Guid id, UpdateEmployeeDetailsRequest request);
    }
}
