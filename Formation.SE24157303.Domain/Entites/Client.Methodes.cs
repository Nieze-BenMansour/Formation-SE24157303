﻿namespace Formation.SE24157303.Domain.Entites;

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
        // Validation de données
        this._identifiantNationale = identifiantNationale;
    }

    public static Client GetDraftClient(int age)
    {
        return new Client() 
        { 
            Age = age,
            Nom = "No name",
            _identifiantNationale = 0
        };
    }

    public static object GetClientAlex(string name)
    {
        if (name == "Alex")
        {
            return new Client { Nom = "Alex" };
        }

        return "not_found";
    }
}
