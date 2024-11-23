using BookTrade.Domain.Primitives;

namespace BookTrade.Domain;

public class User: Entity
{
    public Location? Location { get; set; }

    public ICollection<Book> BooksAvailableForTrade { get; set; } = new List<Book>();

    public ICollection<Trade> InitiatedTrades { get; set; } = new List<Trade>();
    public ICollection<Trade> ReceivedTrades { get; set; } = new List<Trade>();

    public IEnumerable<Trade> TradedBooks => InitiatedTrades.Concat(ReceivedTrades);

    public int TotalTradedBooks => TradedBooks.Count();

    /* TODO: This one should represent how trustworthy this user is
            when specifying book conditions and trading. */
    public decimal Rating => 0;
}