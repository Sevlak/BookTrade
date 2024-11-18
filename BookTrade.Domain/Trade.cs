using BookTrade.Domain.Enums;
using BookTrade.Domain.Primitives;

namespace BookTrade.Domain;

public class Trade: Entity
{
    public User Trader { get; set; }
    public User TradedWith { get; set; }

    public Book BookToTrade { get; set; }
    public Book TradedFor { get; set; }

    public DateTime TradeDate { get; set; }
    public TradeStatus Status { get; set; }
}