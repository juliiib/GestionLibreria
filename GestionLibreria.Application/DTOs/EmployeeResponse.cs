using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using static GestionLibreria.Domain.Entities.Employee;

namespace GestionLibreria.Application.DTOs
{
    public record EmployeeResponse(
        Guid Id, 
        string Dni, 
        string Name, 
        string LastName, 
        string Mail, 
        string Address, 
        string Phone, 
        ShiftEnum Shift, 
        RoleEnum Role, 
        DateTime HireDate)
    {
        public static EmployeeResponse FromEmployee(Employee employee)
        {
            return new EmployeeResponse(
                employee.Id, 
                employee.Dni, 
                employee.Name, 
                employee.LastName, 
                employee.Mail, 
                employee.Address, 
                employee.Phone, 
                employee.Shift, 
                employee.Role, 
                employee.HireDate);
        }
    }
}
