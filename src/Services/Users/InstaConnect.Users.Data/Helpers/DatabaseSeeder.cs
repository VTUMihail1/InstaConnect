using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Data.Abstraction;
using InstaConnect.Users.Data.Models.Entities;
using InstaConnect.Users.Data.Models.Enums;
using InstaConnect.Users.Data.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InstaConnect.Users.Data.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AdminOptions _adminOptions;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserRepository _userRepository;
    private readonly IUserClaimRepository _userClaimRepository;

    public DatabaseSeeder(
        IUnitOfWork unitOfWork,
        IOptions<AdminOptions> options,
        IPasswordHasher passwordHasher,
        IUserRepository userRepository,
        IUserClaimRepository userClaimRepository)
    {
        _unitOfWork = unitOfWork;
        _adminOptions = options.Value;
        _passwordHasher = passwordHasher;
        _userRepository = userRepository;
        _userClaimRepository = userClaimRepository;
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        await SeedAdminAsync(cancellationToken);
    }

    public async Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken)
    {
        var pendingMigrations = await _unitOfWork.Database.GetPendingMigrationsAsync(cancellationToken);

        if (pendingMigrations.Any())
        {
            await _unitOfWork.Database.MigrateAsync(cancellationToken);
        }
    }

    private async Task SeedAdminAsync(CancellationToken cancellationToken)
    {
        if (await _userRepository.AnyAsync(cancellationToken))
        {
            return;
        }

        var adminUser = new User
        {
            FirstName = "Admin",
            LastName = "Admin",
            Email = _adminOptions.Email,
            UserName = "InstaConnectAdmin",
            PasswordHash = _passwordHasher.Hash(_adminOptions.Password).PasswordHash,
        };

        var adminClaim = new UserClaim
        {
            UserId = adminUser.Id,
            Claim = Claims.Admin,
            Value = nameof(Claims.Admin)
        };

        _userRepository.Add(adminUser);
        await _userRepository.ConfirmEmailAsync(adminUser.Id, cancellationToken);
        _userClaimRepository.Add(adminClaim);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
