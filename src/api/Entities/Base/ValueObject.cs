namespace api.Entities.Base;

public abstract record ValueObject
{
    public abstract string Value { get; protected set; }
}
