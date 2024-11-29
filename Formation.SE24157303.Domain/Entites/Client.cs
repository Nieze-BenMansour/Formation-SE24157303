using Formation.SE24157303.Domain.BaseTypes;
using System.Text.RegularExpressions;

namespace Formation.SE24157303.Domain.Entites;

// type réference (stockage ça va être en mémoire heap)
public partial class Client : AuditEntity, IBaseEntity<int>, IAuditEntity
{
    public Client()
    {
        
    }
    public Client(
        int age,
        string nom,
        int identifiantNationale,
        ClientType clientType,
        string email)
    {
        Age = age;
        Nom = nom;
        IdentifiantNationale = identifiantNationale;
        ClientType = clientType;
        _email = email;
    }

    // propriétes 
    public int Id { get; set; }

    public int Age { get; set; } // PascalCase si public

    public string Nom { get; set; } // PascalCase si public

    public int IdentifiantNationale { get; set; }

    public ClientType ClientType { get; set; }

    public string Email 
    { 
        get
        {
            return _email;
        }

        set 
        {
            if (value is null)
            {
                return;
            }
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            bool isValidEmail = Regex.IsMatch(value, emailPattern);

            if (isValidEmail) { _email = value; }
            else { _email = "email_non_valide"; }
        } 
    }

    private string _email;
}