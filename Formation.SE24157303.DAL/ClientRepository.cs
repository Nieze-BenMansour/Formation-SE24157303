using Formation.SE24157303.Domain.Entites;

namespace Formation.SE24157303.DAL;

public class ClientRepository : Repository<Client>
{
    public ClientRepository(string filePath) : base(filePath)
    {
    }

    public IEnumerable<Client> GetClientsMajeur()
    {
        return EntitiesDataStore.Where(e => e.Age > 18);
    }

    public IEnumerable<Client> GetClientsMinuer()
    {
        return from Client c in EntitiesDataStore where c.Age > 18 select c;
    }
}
