using GestionLibreria.Application.DTOs;
using GestionLibreria.Application.Interfaces;
using GestionLibreria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GestionLibreria.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientRepository;

        public ClientController(IClientService clientService)
        {
            _clientRepository = clientService;
        }

        [HttpPost]
        public ActionResult<Client> Create([FromBody] CreateClientRequest request)
        {
            try
            {
                ClientResponse client = _clientRepository.AddClient(request);

                return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, client);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<ClientResponse>> GetAll()
        {
            var clients = _clientRepository.GetAllClients();
            if (!clients.Any())
            {
                return NotFound("No clients found.");
            }
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public ActionResult<ClientResponse> GetClientById(Guid id)
        {
            var client = _clientRepository.GetClientById(id);
            if (client == null)
            {
                return NotFound("Client not found.");
            }
            return Ok(client);
        }

        [HttpPatch("{id}")]
        public ActionResult Update([FromRoute] Guid id, [FromBody] UpdateClientRequest request)
        {
            if (!_clientRepository.UpdateClient(id, request))
            {
                return NotFound("Client not found.");
            }

            return NoContent();
        }
    }
}

