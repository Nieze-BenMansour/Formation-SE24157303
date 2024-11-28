using Formation.SE24157303.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Formation.SE24157303.DAL;

public class SalesContext : DbContext
{
    public SalesContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Client> ClientDbset { get; set; }
}
