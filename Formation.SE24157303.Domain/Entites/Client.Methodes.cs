namespace Formation.SE24157303.Domain.Entites;

public partial class Client
{
    public static Client GetDraftClient()
    {
        return new Client
            (
                age: 0,
                nom: "no_name",
                identifiantNationale: 0,
                clientType: ClientType.PersonnePhysique,
                email: string.Empty
            );
    }
}
