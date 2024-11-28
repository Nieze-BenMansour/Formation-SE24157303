using Formation.SE24157303.Domain.BaseTypes;

namespace Formation.SE24157303.DAL;

public interface IRepository<TEntity> where TEntity : AuditEntity, IBaseEntity<int>
{
    IEnumerable<TEntity> GetAll();
    
    TEntity? GetById(int id);

    /// <summary>
    /// Sert à créer des entités métier de type AuditEntity et IBaseEntity.
    /// </summary>
    /// <param name="entity">Entité métier en question.</param>
    /// <returns>ça designe le nombre totale des enregistrements.</returns>
    int Create(TEntity entity);
    
    void Delete(TEntity entity);
    
    void Update(TEntity entity);
}
