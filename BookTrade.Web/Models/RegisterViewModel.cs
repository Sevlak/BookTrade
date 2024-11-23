using System.ComponentModel.DataAnnotations;

namespace BookTrade.Web.Models;

public record RegisterViewModel
{
    [StringLength(20, MinimumLength = 6, ErrorMessage = "Username must be between 6 and 20 characters long.")]
    public string Username { get; init; }

    [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email address.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; init; }

    [StringLength(30, MinimumLength = 10, ErrorMessage = "Password must be between 10 and 30 characters long.")]
    [DataType(DataType.Password)]
    public string Password { get; init; }

    public bool AgreedToTermsAndConditions { get; init; }
}