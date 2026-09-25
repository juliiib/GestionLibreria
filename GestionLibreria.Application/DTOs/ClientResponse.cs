using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Application.DTOs
{
    public record ClientResponse(
        Guid Id, 
        string Dni, 
        string Name, 
        string LastName, 
        string Mail, 
        string Address, 
        string Phone)
    {
        public static ClientResponse FromClient(Client client)
        {
            return new ClientResponse(
                client.Id, 
                client.Dni, 
                client.Name, 
                client.LastName,
                client.Mail, 
                client.Address, 
                client.Phone);
        }
    }
}
