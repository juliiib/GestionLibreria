using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        void AddEmployee(Employee employee);

        IReadOnlyList<Employee> GetAllEmployees();

        Employee? GetEmployeeById(Guid id);

        void RemoveEmployee(Employee employee);

        void UpdateEmployeeContact(Employee employee);
        
        void UpdateEmployeeDetails(Employee employee);

    }
}
