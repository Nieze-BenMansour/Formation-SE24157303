using Formation.SE24157303.Domain.BaseTypes;

namespace Formation.SE24157303.Domain.Entites;

internal class Facture : AuditEntity, IAuditEntity
{
    public int Numero { get; set; }
}
