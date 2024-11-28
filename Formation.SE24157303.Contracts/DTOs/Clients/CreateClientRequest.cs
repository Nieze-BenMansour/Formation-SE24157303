using Formation.SE24157303.Domain.Entites;

namespace Formation.SE24157303.Contracts.DTOs.Clients;

// POCO : Plain Old CLR Object en POJO
// DTO : Data Transfert Object
public class CreateClientRequest
{
    public int Age { get; set; }

    public string Nom { get; set; }

    public int IdentifiantNationale { get; set; }

    public ClientType ClientType { get; set; }

    public string Email { get; set; }
}
