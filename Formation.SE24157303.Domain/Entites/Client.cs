using Formation.SE24157303.Domain.BaseTypes;

namespace Formation.SE24157303.Domain.Entites;

// type réference (stockage ça va être en mémoire heap)
public partial class Client : AuditEntity, IBaseEntity, IAuditEntity
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
    
    public int Id { get; set; }

    private int _identifiantNationale; // camelCase si private

}