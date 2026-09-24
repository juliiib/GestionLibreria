using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;
using GestionLibreria.Infrastructure.Persistence;

namespace GestionLibreria.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly GestionLibreriaDbContext _context;
        public ClientRepository(GestionLibreriaDbContext context)
        {
            this._context = context;
        }

        public void AddClient(Client client) => _context.Clients.Add(client);
        public IReadOnlyList<Client> GetAllClients() => _context.Clients.ToList();
        public Client? GetClientById(Guid id) => _context.Clients.FirstOrDefault(c => c.Id == id);
        public void RemoveClient(Client client) => _context.Clients.Remove(client);
        public void UpdateClient(Client client) => _context.Clients.Update(client);

    }
}
