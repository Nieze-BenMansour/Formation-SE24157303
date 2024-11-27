using Formation.SE24157303.Domain.BaseTypes;

namespace Formation.SE24157303.Domain.Entites;

public abstract class Document : AuditEntity
{
    protected Document()
    {
        
    }

    protected Document(decimal montantTTC, decimal montantHT)
    {
        MontantTTC = montantTTC;
        MontantHT = montantHT;
    }

    public decimal MontantTTC { get; set; }

    protected decimal MontantHT { get; set; } = 500;

    public virtual string GetMontantTTCFormat()
    {
        return "1500";
    }

    public abstract string GetContenueImpression();
}