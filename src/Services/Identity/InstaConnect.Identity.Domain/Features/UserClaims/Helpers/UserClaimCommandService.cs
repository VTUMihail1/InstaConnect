namespace InstaConnect.Identity.Domain.Features.UserClaims.Helpers;

internal class UserClaimCommandService : IUserClaimCommandService
{
    private readonly IUserClaimFactory _claimFactory;
    private readonly IUserCommandRepository _repository;
    private readonly IUserClaimCommandRepository _claimRepository;

    public UserClaimCommandService(
        IUserClaimFactory claimFactory,
        IUserCommandRepository repository,
        IUserClaimCommandRepository claimRepository)
    {
        _claimFactory = claimFactory;
        _repository = repository;
        _claimRepository = claimRepository;
    }

    public async Task<UserClaimId> AddAsync(AddUserClaimCommand command, CancellationToken cancellationToken)
    {
        var user = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException(command.Id);
        }

        var newUserClaim = _claimFactory.Create(command.Id, command.Claim).AddUser(user);
        var userClaim = await _claimRepository.GetByIdAsync(newUserClaim.Id, cancellationToken);

        if (userClaim != null)
        {
            throw new UserClaimAlreadyExistsException(newUserClaim.Id);
        }

        await _claimRepository.AddAsync(newUserClaim, cancellationToken);

        return newUserClaim.Id;
    }

    public async Task DeleteAsync(DeleteUserClaimCommand command, CancellationToken cancellationToken)
    {
        var userNotExists = !await _repository.ExistsByIdAsync(command.Id.Id, cancellationToken);

        if (userNotExists)
        {
            throw new UserNotFoundException(command.Id.Id);
        }

        var userClaim = await _claimRepository.GetByIdAsync(command.Id, cancellationToken);

        if (userClaim == null)
        {
            throw new UserClaimNotFoundException(command.Id);
        }

        await _claimRepository.DeleteAsync(userClaim, cancellationToken);
    }
}
