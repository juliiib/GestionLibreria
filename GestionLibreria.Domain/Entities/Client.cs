using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Entities
{
    public class Client : User
    {
        public DateTime RegistrationDate { get; }
        public int LoyaltyPoints { get; private set; }

        protected Client() { }

        public Client(string dni, string name, string lastName, string mail, string passWordHash, string address, string phone)
            : base(dni, name, lastName, mail, passWordHash, address, phone)
        {
            RegistrationDate = DateTime.UtcNow;
            LoyaltyPoints = 0;
        }
    }
}
