using System.ComponentModel.DataAnnotations;

namespace BookTrade.Web.Models;

public record LoginViewModel
{
    public string Username { get; init; }

    [DataType(DataType.Password)] public string Password { get; init; }
}