using api.Entities.Base;

namespace api.Entities;

public sealed class Sanction : Entity<string>
{
    public string Motif { get; private set; }
    public decimal Amount { get; private set; }
    public Student Student { get; private set; }
    public Secretary Secretary { get; private set; }
    public bool PaidStatus { get; private set; }

    private Sanction(
        string id,
        Secretary secretary,
        Student student,
        string motif,
        decimal amount) : base(id)
    {
        Motif = motif;
        Amount = amount;
        Secretary = secretary;
        Student = student;
    }

    // For Entity Framework concerns
    #pragma warning disable CS8618
    private Sanction()
    {}
    #pragma warning restore CS8618

    public static Sanction Create(Secretary secretary, Student student, string motif, decimal amount)
    {
        return new(
            Guid.NewGuid().ToString(),
            secretary,
            student,
            motif,
            amount
        );
    }

    public bool Pay()
    {
        PaidStatus = true;
        return true;
    }

    public bool Rollback()
    {
        PaidStatus = false;
        return true;
    }
}
