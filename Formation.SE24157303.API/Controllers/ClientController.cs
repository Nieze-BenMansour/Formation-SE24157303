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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        _logger.LogInformation("L'action get du controller Client est appellée");
        List<Client> clients = _clientRepository.GetAll().ToList();
        _logger.LogInformation("Récuperation des clients : succées");

        return Ok(clients);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody]Client client)
    {
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
        clientToUpdate.SetIdentifiantNationale(client.GetIdentifiantNationale());

        _clientRepository.Update(clientToUpdate);

        return NoContent();
    }
}
