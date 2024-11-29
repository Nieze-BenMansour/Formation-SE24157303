using Formation.SE24157303.Contracts.DTOs.Clients;
using Formation.SE24157303.DAL;
using Formation.SE24157303.Domain.Entites;
using Formation.SE24157303.Domain.Exceptions;
using Formation.SE24157303.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Formation.SE24157303.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientController : ControllerBase
{
    private readonly IRepository<Client> _clientRepository;
    private readonly ILogger<ClientController> _logger;
    private readonly IClientService _clientService;

    public ClientController(
        IRepository<Client> clientRepository,
        ILogger<ClientController> logger,
        IClientService clientService)
    {
        _clientRepository = clientRepository;
        _logger = logger;
        _clientService = clientService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetClientResponse>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        _logger.LogInformation("L'action get du controller Client est appellée");
        
        List<GetClientResponse> GetClientResponses = _clientService.GetAll().ToList();

        _logger.LogInformation("Récuperation des {ResponseName} : succées ({ResponseCount})",
            nameof(GetClientResponse),
            GetClientResponses.Count);

        return Ok(GetClientResponses);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] CreateClientRequest createClientRequest)
    {
        // Req : méthode d'extension pour le mapping entité -> DTO et vice-versa.
        // Req : nuget packages pour le mapping entité -> DTO et vice-versa, par le package AutoMapper ou Mapster.

        var clientId = _clientService.Create(createClientRequest);

        return Created($"/Client/{clientId}", createClientRequest);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get(int id) // id c'est paramétre dans l'url
    {
        Client? client = _clientRepository.GetById(id);

        if (client is null)
        {
            return NotFound();
        }

        return Ok(client);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete(int id) // id c'est paramétre dans l'url
    {
        try
        {
            _logger.LogInformation("L'action delete du controller Client est appellée");

            _clientRepository.Delete(id);

            return NoContent();
        } 
        catch (ClientNotFoundException ex)
        {
            _logger.LogWarning(ex.Message,ex);

            return NotFound();
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Update(int id, [FromBody] UpdateClientRequest updateClientRequest)
    {
        // TODO validation de données
        _logger.LogInformation("L'action update du controller Client est appellée");

        var clientToUpdate = _clientRepository.GetById(id);

        if (clientToUpdate is null)
        {
            _logger.LogWarning("Client non trouvé");
            return NotFound();
        }

        clientToUpdate.Nom = updateClientRequest.Nom;
        clientToUpdate.Age = updateClientRequest.Age;
        clientToUpdate.Email = updateClientRequest.Email;
        clientToUpdate.IdentifiantNationale = updateClientRequest.IdentifiantNationale;
        clientToUpdate.ClientType = updateClientRequest.ClientType;

        _clientRepository.Update(clientToUpdate);

        return NoContent();
    }
}
