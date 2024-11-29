using Formation.SE24157303.Domain.Entites;

namespace Formation.SE24157303.Contracts.DTOs.Clients;

// En réalité UpdateClientRequest sera fractionné sur plusieurs fonctionnalité de notre systéme.
public class UpdateClientRequest
{
    public int Age { get; set; }

    public string Nom { get; set; }

    public int IdentifiantNationale { get; set; }

    public ClientType ClientType { get; set; }

    public string Email { get; set; }
}
