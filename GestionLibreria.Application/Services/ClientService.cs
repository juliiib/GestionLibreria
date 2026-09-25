using System;
using System.Collections.Generic;
using System.Text;
using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using GestionLibreria.Domain.Interfaces;

namespace GestionLibreria.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public ClientResponse AddClient(CreateClientRequest request)
        {
            var client = new Client(request.Dni, request.Name, request.LastName, request.Mail, request.PassWordHash, request.Address, request.Phone);

            clientRepository.AddClient(client);

            return ClientResponse.FromClient(client);
        }

        public IReadOnlyList<ClientResponse> GetAllClients()
        {
            var clients = clientRepository.GetAllClients();
            return clients.Select(ClientResponse.FromClient).ToList();
        }

        public ClientResponse? GetClientById(Guid id)
        {
            var client = clientRepository.GetClientById(id);
            return client != null ? ClientResponse.FromClient(client) : null;
        }

        public void RemoveClient(Guid id)
        {
            var client = clientRepository.GetClientById(id);
            
            if (client == null) {
                return;
            }

            clientRepository.RemoveClient(client);
        }

        public bool UpdateClient(Guid id, UpdateClientRequest request)
        {
            var client = clientRepository.GetClientById(id);

            if (client == null)
            {
                return false;
            }
            
            client.UpdateProfile(request.Mail, request.PassWordHash, request.Address, request.Phone);

            clientRepository.UpdateClient(client);

            return true;
        }
    }
}
