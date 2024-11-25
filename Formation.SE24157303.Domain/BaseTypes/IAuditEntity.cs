namespace Formation.SE24157303.Domain.BaseTypes;

public interface IAuditEntity
{
    // Audit
    DateTime DateCreation { get; set; }

    DateTime DateDerniereModification { get; set; }

    string UserCreation { get; set; }

    string UserModification { get; set; }
}
