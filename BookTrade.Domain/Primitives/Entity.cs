namespace BookTrade.Domain.Primitives;

public abstract class Entity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
}