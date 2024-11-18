using BookTrade.Domain.Primitives;

namespace BookTrade.Domain;

public class User: Entity
{
    public string Name { get; set; }
    public Location Location { get; set; }

    private ICollection<Book> BooksAvailableForTrade { get; set; }
    private ICollection<Trade> TradedBooks { get; set; }

    public int TotalTradedBooks => TradedBooks.Count;

    /* TODO: This one should represent how trustworthy this user is
            when specifying book conditions and trading. */
    public decimal Rating => 0;
}