namespace Formation.SE24157303.Contracts.DTOs.Clients;

public class GetClientResponse
{
    public int Id { get; set; }

    public int Age { get; set; } // PascalCase si public

    public string Nom { get; set; } // PascalCase si public

    public int IdentifiantNationale { get; set; }
}
