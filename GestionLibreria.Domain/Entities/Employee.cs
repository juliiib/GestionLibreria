using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Entities
{
    public class Employee : User
    {
        public enum ShiftEnum { Morning, Afternoon, Night }
        public enum RoleEnum { Manager, Seller, Admin }

        public decimal Salary { get; private set; }
        public ShiftEnum Shift { get; private set; }
        public DateTime HireDate { get; }
        public RoleEnum Role { get; private set; }

        protected Employee() { }

        public Employee(string dni, string name, string lastName, string mail, string passWordHash, string address, string phone, decimal salary, ShiftEnum shift, DateTime hireDate, RoleEnum role)
            : base(dni, name, lastName, mail, passWordHash, address, phone)
        {
            if (salary < 0)
            {
                throw new ArgumentException("Salary cannot be negative.", nameof(salary));
            }

            Salary = salary;
            Shift = shift;
            HireDate = hireDate;
            Role = role;
        }
    }
}
