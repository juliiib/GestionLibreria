using System;
using System.Collections.Generic;
using System.Text;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.DTOs
{
    public record CreateEmployeeRequest(string Dni, string Name, string LastName, string Mail, string PassWordHash, string Address, string Phone, decimal Salary, Employee.ShiftEnum Shift, DateTime HireDate, Employee.RoleEnum Role);
}
