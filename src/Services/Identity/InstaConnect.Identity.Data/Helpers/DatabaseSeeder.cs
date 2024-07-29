using InstaConnect.Identity.Data.Features.UserClaims.Abstractions;
using InstaConnect.Identity.Data.Features.UserClaims.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Abstractions;
using InstaConnect.Identity.Data.Features.Users.Models.Entitites;
using InstaConnect.Identity.Data.Features.Users.Models.Options;
using InstaConnect.Shared.Data.Abstractions;
using InstaConnect.Shared.Data.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Data.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AdminOptions _adminOptions;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserClaimWriteRepository _userClaimWriteRepository;

    public DatabaseSeeder(
        IUnitOfWork unitOfWork,
        IOptions<AdminOptions> options,
        IPasswordHasher passwordHasher,
        IUserWriteRepository userWriteRepository,
        IUserClaimWriteRepository userClaimWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _adminOptions = options.Value;
        _passwordHasher = passwordHasher;
        _userWriteRepository = userWriteRepository;
        _userClaimWriteRepository = userClaimWriteRepository;
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
        if (await _userWriteRepository.AnyAsync(cancellationToken))
        {
            return;
        }

        var adminUser = new User(
            "Admin",
            "Admin",
            _adminOptions.Email,
            "InstaConnectAdmin",
            _passwordHasher.Hash(_adminOptions.Password).PasswordHash,
            null);
        await _userWriteRepository.ConfirmEmailAsync(adminUser.Id, cancellationToken);

        var adminClaim = new UserClaim(AppClaims.Admin, AppClaims.Admin, adminUser.Id);

        _userWriteRepository.Add(adminUser);
        _userClaimWriteRepository.Add(adminClaim);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
