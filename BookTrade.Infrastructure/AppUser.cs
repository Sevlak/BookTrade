using BookTrade.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookTrade.Infrastructure;

public class AppUser : IdentityUser
{
    public int DomainUserId { get; set; }
    public User DomainUser { get; set; }
}