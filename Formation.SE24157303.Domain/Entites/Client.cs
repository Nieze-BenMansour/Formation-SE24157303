using Formation.SE24157303.Domain.BaseTypes;
using System.Text.RegularExpressions;

namespace Formation.SE24157303.Domain.Entites;

// type réference (stockage ça va être en mémoire heap)
public partial class Client : AuditEntity, IBaseEntity<int>, IAuditEntity
{
    // Constructeurs
    public Client()
    {
    }

    public Client(int age, int identifiantNationale, string nom)
    {
        Age = age;
        Nom = nom;
        _identifiantNationale = identifiantNationale;
    }

    public Client(int age, string nom)
    {
        Age = age;
        Nom = nom;
    }

    // propriétes 
    public int Age { get; set; } // PascalCase si public

    public string Nom { get; set; } // PascalCase si public

    private string _email;
    public string Email 
    { 
        get
        {
            return _email;
        }

        set 
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            bool isValidEmail = Regex.IsMatch(value, emailPattern);

            if (isValidEmail) { _email = value; }
            else { _email = "email_non_valide"; }
            
        } 
    }

    public int Id { get; set; }

    private int _identifiantNationale; // camelCase si private
}