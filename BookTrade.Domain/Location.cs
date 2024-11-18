namespace BookTrade.Domain;

public record Location
{
    public string? ZipCode { get; set; }
    public string? City { get; set; }
}