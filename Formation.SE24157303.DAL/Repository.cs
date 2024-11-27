using Formation.SE24157303.Domain.BaseTypes;

namespace Formation.SE24157303.DAL;

public class Repository<TEntity> where TEntity : AuditEntity ,IBaseEntity<int>
{
    public List<TEntity> EntitiesDataStore { get; set; } = new List<TEntity>();

    // CRUD
    public IEnumerable<TEntity> GetAll()
    {
        return EntitiesDataStore;
    }

    public TEntity? GetById(int id)
    {
        // Linq
        return EntitiesDataStore.FirstOrDefault(entity => entity.Id == id);
    }

    public virtual int Create(TEntity entity)
    {
        EntitiesDataStore.Add(entity);

        return EntitiesDataStore.Count;
    }

    public void Delete(TEntity entity)
    {
        EntitiesDataStore.Remove(entity);
    }

    /// <summary>
    /// C'est une méthode qui modifie un client.
    /// </summary>
    /// <param name="entity">Un client</param>
    /// <exception cref="ArgumentNullException"></exception>
    public void Update(TEntity entity)
    {
        var entityToUpdate = EntitiesDataStore.FirstOrDefault(e => e.Id == entity.Id);
        if (entityToUpdate is null)
        {
            throw new ArgumentNullException("On n'a trouvé l'entité");
        }

        EntitiesDataStore.Remove(entityToUpdate);
        EntitiesDataStore.Add(entity);
    }
}
