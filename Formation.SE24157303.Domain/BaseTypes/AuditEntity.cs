namespace Formation.SE24157303.Domain.BaseTypes;

public class AuditEntity
{
    // Audit
    public DateTime DateCreation { get; set; }

    public DateTime DateDerniereModification { get; set; }

    public string UserCreation { get; set; }

    public string UserModification { get; set; }
}
