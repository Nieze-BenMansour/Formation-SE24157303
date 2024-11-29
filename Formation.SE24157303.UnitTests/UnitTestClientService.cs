using Formation.SE24157303.Contracts.DTOs.Clients;
using Formation.SE24157303.DAL;
using Formation.SE24157303.Domain.Entites;
using Formation.SE24157303.Services;
using Microsoft.EntityFrameworkCore;

namespace Formation.SE24157303.UnitTests
{
    public class UnitTestClientService
    {
        [Fact]
        public void GetAll_MustReturnAClientList()
        {
            // Arrange
            DbContextOptions dbContextOptions = new DbContextOptionsBuilder<SalesContext>()
                .UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=SalesDb;Data Source=LAPTOP-UR7S8C4K;Encrypt=False;")
                .Options;
            SalesContext salesContext = new SalesContext(dbContextOptions);
            DbRepository<Client> dbRepository = new DbRepository<Client> (salesContext);
            ClientService clientService = new ClientService(dbRepository);

            // Act
            List<GetClientResponse> getClientResponses = clientService.GetAll().ToList();

            // Assert
            Assert.NotNull(getClientResponses);
            Assert.True(getClientResponses.Any());
        }
    }
}