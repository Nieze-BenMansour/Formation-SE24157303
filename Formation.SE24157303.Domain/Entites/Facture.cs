using Formation.SE24157303.Domain.BaseTypes;

namespace Formation.SE24157303.Domain.Entites;

public sealed class Facture : Document, IAuditEntity, IBaseEntity<int>
{
    public Facture()
    {
        
    }

    public Facture(decimal montantTTC, decimal montantHT) 
        : base(montantTTC, montantHT)
    {
    }

    public int Numero { get; set; }

    public int Id { get; set; }

    public override string GetContenueImpression()
    {
        return $"<h1>Num : {this.Numero}</h1>";
    }

    public override string GetMontantTTCFormat()
    {
        string montantBase = base.GetMontantTTCFormat();
        return 
            $"Base : {montantBase} Facture : 2000, HT : {MontantHT}";
    }
}