using BookTrade.Domain;
using BookTrade.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace BookTrade.Application.Services;

public class UserService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly SignInManager<AppUser> _signInManager;

    public UserService(UserManager<AppUser> userManager, ApplicationDbContext context, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _context = context;
        _signInManager = signInManager;
    }

    public async Task<IdentityResult> CreateUserAsync(string email, string username, string password)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();

        var domainUser = new User
        {
            CreatedAt = DateTime.UtcNow,
            Location = null
        };

        await _context.Set<User>().AddAsync(domainUser);
        await _context.SaveChangesAsync();

        var user = new AppUser
        {
            UserName = username,
            Email = email,
            DomainUserId = domainUser.Id
        };

        var result = await _userManager.CreateAsync(user, password);

        if (result.Succeeded)
            await transaction.CommitAsync();
        else
            await transaction.RollbackAsync();

        return result;
    }

    public async Task<SignInResult> LoginUserAsync(string username, string password)
    {
        var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

        return result;
    }
}