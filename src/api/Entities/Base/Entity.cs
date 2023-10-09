namespace api.Entities.Base;

public abstract class Entity<T>
{
    public T Id { get; protected set; }
    protected Entity(T id)
    {
        Id = id;
    }

    #pragma warning disable CS8618
    protected Entity()
    {}
    #pragma warning restore CS8618
}
