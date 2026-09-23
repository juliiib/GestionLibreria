using GestionLibreria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestionLibreria.Domain.Interfaces
{
    public interface IClientRepository
    {
        void AddClient(Client client);

        IReadOnlyList<Client> GetAllClients();

        Client? GetClientById(int id);

        bool RemoveClient(Client client);

        void UpdateClient(Client client);
    }
}
