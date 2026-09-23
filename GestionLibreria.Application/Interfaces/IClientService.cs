using System;
using System.Collections.Generic;
using System.Text;
using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.Interfaces
{
    public interface IClientService
    {
        Client AddClient(CreateClientRequest request);

        IReadOnlyList<Client> GetAllClients();

        Client? GetClientById(int id);

        bool RemoveClient(int id);

        bool UpdateClient(int id, UpdateClientRequest request);
    }
}
