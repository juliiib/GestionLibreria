using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.Interfaces
{
    public interface IClientService
    {
        Client AddClient(CreateClientRequest request);

        IReadOnlyList<Client> GetAllClients();

        Client? GetClientById(Guid id);

        void RemoveClient(Guid id);

        bool UpdateClient(Guid id, UpdateClientRequest request);
    }
}
