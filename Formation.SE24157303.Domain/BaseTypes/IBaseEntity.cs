namespace Formation.SE24157303.Domain.BaseTypes;

public interface IBaseEntity<TPrimaryKey>
{
    TPrimaryKey Id { get; set; }
}
