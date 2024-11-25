


// instantiation vide
// constructeur sans paramètre ou constructeur par défaut.
// var client = new Client();


// constructeur sans paramètre ou constructeur par défaut.
using Formation.SE24157303.ConsoleApp;
using Formation.SE24157303.Domain.BaseTypes;

IBaseEntity client1 = new Client()
{
    Age = 18,
    Nom = "Alex"
};

var client2 = new Client(age: 18, nom: "Alex", identifiantNationale: 115599);


Client client = new();

// affectation
client.Age = 18;
client.Nom = "Alex";
client.SetIdentifiantNationale(152158478);

Console.WriteLine(client.Nom.Length);


Console.WriteLine(IdantifantHelper.NombreDigitsAffiche);

IdantifantHelper.GetBonFormat(client.GetIdentifiantNationale());