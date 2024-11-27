using Formation.SE24157303.Domain.BaseTypes;

namespace Formation.SE24157303.DAL;

public class Repository<TEntity> where TEntity : AuditEntity
{
    public List<TEntity> EntitiesDataStore { get; set; } = new List<TEntity>();

    public IEnumerable<TEntity> GetAll()
    {
        return EntitiesDataStore;
    }

    public virtual int Add(TEntity entity)
    {
        EntitiesDataStore.Add(entity);

        return EntitiesDataStore.Count;
    }

    public void Delete(TEntity entity)
    {
        EntitiesDataStore.Remove(entity);
    }
}
