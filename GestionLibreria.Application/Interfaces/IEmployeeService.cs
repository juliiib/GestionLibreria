using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeResponse AddEmployee(CreateEmployeeRequest request);

        IReadOnlyList<EmployeeResponse> GetAllEmployees();

        EmployeeResponse? GetEmployeeById(Guid id);

        void RemoveEmployee(Guid id);

        bool UpdateEmployeeContact(Guid id, UpdateEmployeeContactRequest request);

        bool UpdateEmployeeDetails(Guid id, UpdateEmployeeDetailsRequest request);
    }
}
