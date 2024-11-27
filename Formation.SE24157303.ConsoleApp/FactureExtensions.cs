namespace Formation.SE24157303.ConsoleApp;

internal static class FactureExtensions
{
    public static string GetMontantTTCEnKhmer(this Facture facture)
    {
        return facture.MontantTTC.ToString("##.00");
    }
}
