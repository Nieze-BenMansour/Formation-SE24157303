using Formation.SE24157303.Domain.BaseTypes;
using Formation.SE24157303.Domain.Exceptions;
using System.Text.Json;

namespace Formation.SE24157303.DAL;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : AuditEntity, IBaseEntity<int>
{
    public List<TEntity> EntitiesDataStore { get; set; } = new List<TEntity>();

    public Repository(string filePath)
    {
        _filePath = filePath;
        EntitiesDataStore = LoadFromFile();
    }

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

    /// <summary>
    /// Sert à créer des entités métier de type AuditEntity et IBaseEntity.
    /// </summary>
    /// <param name="entity">Entité métier en question.</param>
    /// <returns>9a designe le nombre totale des enregistrements.</returns>
    public virtual int Create(TEntity entity)
    {
        EntitiesDataStore.Add(entity);
        SaveToFile();

        return EntitiesDataStore.Count;
    }

    public void Delete(TEntity entity)
    {
        EntitiesDataStore.Remove(entity);
        SaveToFile();
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
            throw new ClientNotFoundException("On n'a trouvé l'entité");
        }

        EntitiesDataStore.Remove(entityToUpdate);
        EntitiesDataStore.Add(entity);

        SaveToFile();
    }

    private readonly string _filePath;

    // Deserialize Json
    private List<TEntity> LoadFromFile()
    {
        if (!File.Exists(_filePath))
        {
            return new List<TEntity>();
        }

        string jsonData = File.ReadAllText(_filePath);

        return JsonSerializer
            .Deserialize<List<TEntity>>(jsonData)
            ?? new List<TEntity>();
    }

    // Serialize Json
    private void SaveToFile()
    {
        string? jsonData = JsonSerializer.Serialize(
            EntitiesDataStore,
            new JsonSerializerOptions
            {
                WriteIndented = true
            });

        File.WriteAllText(_filePath, jsonData);
    }
}
