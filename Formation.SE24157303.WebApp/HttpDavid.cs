namespace Formation.SE24157303.WebApp;

public class HttpDavid : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
