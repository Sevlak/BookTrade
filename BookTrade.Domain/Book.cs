using BookTrade.Domain.Enums;
using BookTrade.Domain.Primitives;

namespace BookTrade.Domain;

public class Book: Entity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string? Description { get; set; }
    public DateOnly PublishedOn { get; set; }
    public Condition Condition { get; set; }
    public ICollection<Category> Categories { get; set; }

    /*
     TODO: This should be the overall book rating on our system.
            For now, set to 0. We'll look for an algorithm to sort
            this out.
    */
    public decimal Rating => 0;
}