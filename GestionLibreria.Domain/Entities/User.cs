using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Entities
{
    public abstract class  User
    {
        public Guid Id { get; private set; }
        public String Dni { get; }
        public String Name { get; }
        public string LastName { get; }
        public string Mail { get; private set; }
        public string PassWordHash { get; private set; }
        public String Address { get; private set; }
        public String Phone { get; private set; }
        public Boolean IsActive { get; private set; }

        protected User() { }
        public User(string dni, string name, string lastName, string mail, string passWordHash, string address, string phone)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new ArgumentException("DNI cannot be null or empty.", nameof(dni));
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));
            }
            if (string.IsNullOrWhiteSpace(mail))
            {
                throw new ArgumentException("Mail cannot be null or empty.", nameof(mail));
            }
            if (string.IsNullOrWhiteSpace(passWordHash))
            {
                throw new ArgumentException("Password hash cannot be null or empty.", nameof(passWordHash));
            }
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("Address cannot be null or empty.", nameof(address));
            }
            if (string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("Phone cannot be null or empty.", nameof(phone));
            }
            
            Id = Guid.NewGuid();
            Dni = dni;
            Name = name;
            LastName = lastName;
            Mail = mail;
            PassWordHash = passWordHash;
            Address = address;
            Phone = phone;
            IsActive = true;
        }

        public void UpdateProfile(string? mail, string? passwordHash, string? address, string? phone)
        {
            if (!string.IsNullOrWhiteSpace(mail)) Mail = mail;
            if (!string.IsNullOrWhiteSpace(passwordHash)) PassWordHash = passwordHash;
            if (!string.IsNullOrWhiteSpace(address)) Address = address;
            if (!string.IsNullOrWhiteSpace(phone)) Phone = phone;
        }
    }
}
