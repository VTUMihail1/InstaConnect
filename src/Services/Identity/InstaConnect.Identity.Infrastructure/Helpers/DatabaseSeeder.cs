using InstaConnect.Common.Utilities;
using InstaConnect.Identity.Infrastructure.Features.Users.Models.Options;

using Microsoft.Extensions.Options;

namespace InstaConnect.Identity.Infrastructure.Helpers;

internal class DatabaseSeeder : IDatabaseSeeder
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AdminOptions _adminOptions;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IdentityContext _identityContext;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserClaimWriteRepository _userClaimWriteRepository;

    public DatabaseSeeder(
        IUnitOfWork unitOfWork,
        IOptions<AdminOptions> options,
        IPasswordHasher passwordHasher,
        IdentityContext identityContext,
        IUserWriteRepository userWriteRepository,
        IUserClaimWriteRepository userClaimWriteRepository)
    {
        _unitOfWork = unitOfWork;
        _adminOptions = options.Value;
        _passwordHasher = passwordHasher;
        _identityContext = identityContext;
        _userWriteRepository = userWriteRepository;
        _userClaimWriteRepository = userClaimWriteRepository;
    }

    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        await SeedAdminAsync(cancellationToken);
    }

    public async Task ApplyPendingMigrationsAsync(CancellationToken cancellationToken)
    {
        var pendingMigrations = await _identityContext.Database.GetPendingMigrationsAsync(cancellationToken);

        if (pendingMigrations.Any())
        {
            await _identityContext.Database.MigrateAsync(cancellationToken);
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
