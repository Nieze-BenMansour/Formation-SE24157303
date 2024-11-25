namespace Formation.SE24157303.Domain.Entites;

public partial class Client
{
    // méthodes

    // Getters & Setters
    public int GetIdentifiantNationale()
    {
        return this._identifiantNationale;
    }

    public void SetIdentifiantNationale(int identifiantNationale)
    {
        this._identifiantNationale = identifiantNationale;
    }

    public static Client GetDraftClient()
    {
        return new Client() { Age = 18, Nom = "No name", _identifiantNationale = 0 };
    }
}
