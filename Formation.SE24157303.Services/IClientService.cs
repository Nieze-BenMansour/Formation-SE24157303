using Formation.SE24157303.Contracts.DTOs.Clients;

namespace Formation.SE24157303.Services;

public interface IClientService
{
    IEnumerable<GetClientResponse> GetAll();

    GetClientResponse? GetById(int id);

    int Create(CreateClientRequest entity);

    void Delete(int entityId);

    void Update(UpdateClientRequest entity);
}
