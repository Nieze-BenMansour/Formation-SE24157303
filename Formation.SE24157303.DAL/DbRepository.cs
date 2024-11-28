using Formation.SE24157303.Domain.BaseTypes;
using Formation.SE24157303.Domain.Exceptions;

namespace Formation.SE24157303.DAL;

public class DbRepository<TEntity>
    : IRepository<TEntity>
    where TEntity : AuditEntity, IBaseEntity<int>
{
    private readonly SalesContext _salesContext;

    public DbRepository(SalesContext salesContext)
    {
        _salesContext = salesContext;
    }

    public int Create(TEntity entity)
    {
        _salesContext.Add(entity);
        _salesContext.SaveChanges();

        return entity.Id;
    }

    public void Delete(int entityId)
    {
        var entityToDelete = _salesContext.Set<TEntity>()
            .FirstOrDefault(entity => entity.Id == entityId);

        if (entityToDelete is null)
        {
            throw new ClientNotFoundException("On n'a trouvé l'entité");
        }

        _salesContext.Remove(entityToDelete);
        _salesContext.SaveChanges();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _salesContext.Set<TEntity>().ToList();
    }

    public TEntity? GetById(int id)
    {
        var entityToGet = _salesContext.Set<TEntity>()
            .FirstOrDefault(entity => entity.Id == id);

        if (entityToGet is null)
        {
            throw new ClientNotFoundException("On n'a trouvé l'entité");
        }

        return entityToGet;
    }

    public void Update(TEntity entity)
    {
        // TODO move to Services
        //var entityToUpdate = _salesContext
        //    .Set<TEntity>()
        //    .FirstOrDefault(e => e.Id == entity.Id);

        //if (entityToUpdate is null)
        //{
        //    throw new ClientNotFoundException("On n'a trouvé l'entité");
        //}

        _salesContext.Update(entity);

        _salesContext.SaveChanges();
    }
}
