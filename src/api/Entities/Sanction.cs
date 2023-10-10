using api.Entities.Base;

namespace api.Entities;

public sealed class Sanction : Entity<string>
{
    public string Motif { get; set; }
    public decimal Amount { get; set; }
    public Student Student { get; set; }
    public Secretary Secretary { get; set; }

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
}
