using Formation.SE24157303.Contracts.DTOs.Clients;
using Formation.SE24157303.DAL;
using Formation.SE24157303.Domain.Entites;
using Formation.SE24157303.Domain.Exceptions;

namespace Formation.SE24157303.Services;

public class ClientService : IClientService
{
    public readonly IRepository<Client> _clientRepository;

    public ClientService(IRepository<Client> clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public int Create(CreateClientRequest createClientRequest)
    {
        var client = new Client
        {
            Age = createClientRequest.Age,
            Nom = createClientRequest.Nom,
            IdentifiantNationale = createClientRequest.IdentifiantNationale,
            ClientType = createClientRequest.ClientType,
            Email = createClientRequest.Email,
        };

        _clientRepository.Create(client);

        return client.Id;
    }

    public void Delete(int entityId)
    {
        var clientExist = _clientRepository.GetById(entityId);

        if (clientExist is null)
        {
            throw new ClientNotFoundException("client_not_found");
        }

        _clientRepository.Delete(entityId);
    }

    public IEnumerable<GetClientResponse> GetAll()
    {
        return _clientRepository
            .GetAllQuery()
            .Select(c => new GetClientResponse
            {
                Age = c.Age,
                Id = c.Id,
                IdentifiantNationale = c.IdentifiantNationale,
                Nom = c.Nom,
            });
    }

    public GetClientResponse? GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(UpdateClientRequest entity)
    {
        //var clientToUpdate = _clientRepository.GetById(entity);

        //if (clientToUpdate is null)
        //{
        //    _logger.LogWarning("Client non trouvé");
        //    return NotFound();
        //}

        //clientToUpdate.Nom = updateClientRequest.Nom;
        //clientToUpdate.Age = updateClientRequest.Age;
        //clientToUpdate.Email = updateClientRequest.Email;
        //clientToUpdate.IdentifiantNationale = updateClientRequest.IdentifiantNationale;
        //clientToUpdate.ClientType = updateClientRequest.ClientType;
    }
}
