using Formation.SE24157303.Contracts.DTOs.Clients;
using Formation.SE24157303.DAL;
using Formation.SE24157303.Domain.Entites;
using Formation.SE24157303.Domain.Exceptions;
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

    public ClientController(
        IRepository<Client> clientRepository,
        ILogger<ClientController> logger)
    {
        _clientRepository = clientRepository;
        _logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetClientResponse>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        _logger.LogInformation("L'action get du controller Client est appellée");
        List<Client> clients = _clientRepository.GetAll().ToList();
        _logger.LogInformation("Récuperation des clients : succées");

        var GetClientResponses = new List<GetClientResponse>();

        foreach (var client in clients)
        {
            GetClientResponses.Add(
                new GetClientResponse() 
                {
                    Age = client.Age,
                    Id = client.Id,
                    IdentifiantNationale = client.IdentifiantNationale,
                    Nom = client.Nom,
                });
        }

        return Ok(GetClientResponses);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody]CreateClientRequest createClientRequest)
    {
        // TODO : méthode d'extension pour le mapping entité -> DTO et vice-versa.
        // TODO : nuget packages pour le mapping entité -> DTO et vice-versa, par le package AutoMapper ou Mapster.
        var client = new Client
            (
                age: createClientRequest.Age,
                nom: createClientRequest.Nom,
                identifiantNationale: createClientRequest.IdentifiantNationale,
                clientType: createClientRequest.ClientType,
                email: createClientRequest.Email
            );

        _clientRepository.Create(client);

        return Created();
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
    public IActionResult Update(int id, [FromBody] Client client)
    {
        _logger.LogInformation("L'action update du controller Client est appellée");

        var clientToUpdate = _clientRepository.GetById(id);

        if (clientToUpdate is null)
        {
            _logger.LogWarning("Client non trouvé");
            return NotFound();
        }

        clientToUpdate.Nom = client.Nom;
        clientToUpdate.Age = client.Age;
        //clientToUpdate.SetIdentifiantNationale(client.GetIdentifiantNationale());

        _clientRepository.Update(clientToUpdate);

        return NoContent();
    }
}
