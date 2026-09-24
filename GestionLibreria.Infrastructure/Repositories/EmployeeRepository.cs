using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;
using GestionLibreria.Infrastructure.Persistence;

namespace GestionLibreria.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly GestionLibreriaDbContext _context;

        public EmployeeRepository(GestionLibreriaDbContext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee employee) => _context.Employees.Add(employee);
        public IReadOnlyList<Employee> GetAllEmployees() => _context.Employees.ToList();
        public Employee? GetEmployeeById(Guid id) => _context.Employees.FirstOrDefault(e => e.Id == id);
        public void RemoveEmployee(Employee employee) => _context.Employees.Remove(employee);
        public void UpdateEmployeeContact(Employee employee) => _context.Employees.Update(employee);
        public void UpdateEmployeeDetails(Employee employee) => _context.Employees.Update(employee);
    }
}
