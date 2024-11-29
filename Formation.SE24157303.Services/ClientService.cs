using Formation.SE24157303.Contracts.DTOs.Clients;
using Formation.SE24157303.DAL;
using Formation.SE24157303.Domain.Entites;

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
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }
}
