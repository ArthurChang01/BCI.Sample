namespace BCI.SharedCores.Interfaces
{
    public interface IEntity<out T>
    {
        T Id { get; }
    }
}