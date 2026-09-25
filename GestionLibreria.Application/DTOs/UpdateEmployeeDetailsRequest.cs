using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
    public record UpdateEmployeeDetailsRequest(decimal? Salary, Employee.ShiftEnum? Shift, Employee.RoleEnum? Role);
}
