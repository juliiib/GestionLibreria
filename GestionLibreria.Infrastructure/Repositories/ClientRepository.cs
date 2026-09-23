using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;

namespace GestionLibreria.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> clients = new List<Client>();
        public void AddClient(Client client) => clients.Add(client);
        public IReadOnlyList<Client> GetAllClients() => clients.AsReadOnly();
        public Client? GetClientById(int id) => clients.Find(c => c.Id == id);
        public bool RemoveClient(Client client) => clients.Remove(client);
        public void UpdateClient(Client client) {}

    }
}
