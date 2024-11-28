using Formation.SE24157303.ConsoleApp;
using Formation.SE24157303.DAL;
using Formation.SE24157303.Domain.Exceptions;
using System.Diagnostics;

bool valeurSortie = true;
const string filePath = "clients.json";
IRepository<Client> clientRepository = new Repository<Client>();

while (valeurSortie)
{
    DisplayMenu();

    int choix = int.Parse(Console.ReadLine());

    switch (choix)
    {
        case (int)ChoixMenu.Ajouter:
            CreateClient(clientRepository);
            break;

        case (int)ChoixMenu.Afficher:
            foreach (var client in clientRepository.GetAll())
            {
                DisplayClient(client);
            }
            break;

        case (int)ChoixMenu.Sortir:
            valeurSortie = false;
            break;

        case (int)ChoixMenu.Modifier:
            try
            {
                UpdateClient(clientRepository);
            }
            catch (ClientNotFoundException ex)
            {
                DisplayError(message: "Client non trouvé!", exception: ex);
            }
            break;

        default:
            break;
    }
}

void DisplayMenu()
{
    Console.WriteLine("Menu");
    Console.WriteLine("1 : Ajouter un client");
    Console.WriteLine("2 : Afficher tout les clients");
    Console.WriteLine("3 : Modifier client");
    Console.WriteLine("0 : Quitter");
}

static void DisplayClient(Client client)
{
    Console.WriteLine($"Nom : {client.Nom}");
    Console.WriteLine($"Age : {client.Age}");
    Console.WriteLine("------");
}

static void CreateClient(IRepository<Client> clientRepository)
{
    Console.WriteLine("Entrer le nom : ");
    string nom = Console.ReadLine();

    // TODO generate manullay auto incrempent de l'id

    Console.WriteLine("Entrer l'age : ");

    try
    {
        string? valeurTmp = Console.ReadLine();

        // TODO Utiliser le int.TryParse pe les out les in (slide 109)
        int age = int.Parse(valeurTmp == string.Empty ? null : valeurTmp);

        var clientToCreate = new Client
            (
                age: age,
                nom: nom,
                identifiantNationale: 0,
                clientType: ClientType.PersonnePhysique,
                email: string.Empty
            );

        clientRepository.Create(clientToCreate);
    }
    catch (FormatException ex)
    {
        DisplayError("Mauvaise format de l'age", ex);
    }
    catch (ArgumentNullException ex)
    {
        DisplayError("Le valeur de l'age est null", ex);
    }
    catch (Exception ex) 
    {
        DisplayError("Probléme survenu! Contacter le service support!", ex);
    }

}

static void DisplayError(string message, Exception exception)
{
    Debug.WriteLine(exception.Message);

    Console.WriteLine("----- Exception --------");
    Console.WriteLine(message);
    Console.WriteLine("*******************");
}

static void UpdateClient(IRepository<Client> clientRepository)
{
    Console.WriteLine("Entrer le nom : ");
    string nom = Console.ReadLine();

    Console.WriteLine("Entrer l'id du client à modifier");
    int idEntityToUpdate = int.Parse(Console.ReadLine());

    Console.WriteLine("Entrer l'age : ");

    int age = int.Parse(Console.ReadLine());

    var clientToUpdate = new Client
            (
                age: age,
                nom: nom,
                identifiantNationale: 0,
                clientType: ClientType.PersonnePhysique,
                email: string.Empty
            );

    clientRepository.Update(clientToUpdate);
}