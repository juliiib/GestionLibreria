using GestionLibreria.Application.DTOs;
using GestionLibreria.Domain.Entities;

namespace GestionLibreria.Application.Interfaces
{
    public interface IClientService
    {
        ClientResponse AddClient(CreateClientRequest request);

        IReadOnlyList<ClientResponse> GetAllClients();

        ClientResponse? GetClientById(Guid id);

        void RemoveClient(Guid id);

        bool UpdateClient(Guid id, UpdateClientRequest request);
    }
}
