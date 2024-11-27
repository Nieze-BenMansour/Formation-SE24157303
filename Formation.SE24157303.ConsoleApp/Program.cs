// instantiation vide
// constructeur sans paramètre ou constructeur par défaut.
// var client = new Client();


// constructeur sans paramètre ou constructeur par défaut.
//using Formation.SE24157303.ConsoleApp;
//using Formation.SE24157303.Domain.BaseTypes;

//int ageAuMoins = 18;

//IBaseEntity client1 = new Client()
//{
//    Age = ageAuMoins,
//    Nom = $"Alex {ageAuMoins}"
//};

//var client2 = new Client(age: 18, nom: "Alex", identifiantNationale: 115599);

//Client client = new();

//// affectation
//client.Age = 18;
//client.Nom = "Alex";
//client.SetIdentifiantNationale(152158478);

//Console.WriteLine(client.Nom.Length);


//Console.WriteLine(IdantifantHelper.NombreDigitsAffiche);

//IdantifantHelper.GetBonFormat(client.GetIdentifiantNationale());

//var draftClient = Client.GetDraftClient(18);

//var client = new Client(
//    age: 18,
//    nom: "Alex",
//    identifiantNationale: 115599);

//client.Email = "test.test";

//Console.WriteLine(client.Email);

//var facture = new Facture();

//var montant = facture.GetMontantTTCFormat();


//Console.WriteLine(montant);


//object obj = Client.GetClientAlex("Alex");

//Client client = obj as Client;

//Client client1 = (Client)obj;

//Console.WriteLine($"{nameof(client)} : {client.Nom} - {nameof(client1)} : {client1.Nom}");


//object obj1 = Client.GetClientAlex("David");

//string notFoundString = (string)obj1;

//Console.WriteLine($"{notFoundString}");

//var client2 = new Client(age: 18, nom: "Alex", identifiantNationale: 115599);

//client2.Matricle = "15";
//client2.Matricle = 15;


//using Formation.SE24157303.DAL;

//var client1 = new Client()
//{
//    Age = 18,
//    Nom = $"Alex {18}"
//};

//var client2 = new Client()
//{
//    Age = 18,
//    Nom = $"Alex2 {18}"
//};

//var repositoryClient = new Repository<Client>();

//repositoryClient.Add(client1);
//repositoryClient.Add(client2);

//foreach (var client in repositoryClient.GetAll())
//{
//    Console.WriteLine(client.Nom);
//}



//Dictionary<int, string> dict = new Dictionary<int, string>();
//dict.Add(1, "David");
//dict.Add(2, "Alex");

//foreach (var item in dict)
//{
//    Console.WriteLine($"cle : {item.Key}  - valeur : {item.Value}");
//}


using Formation.SE24157303.ConsoleApp;

var facture = new Facture();

facture.GetMontantTTCFormat();

facture.GetMontantTTCEnKhmer();