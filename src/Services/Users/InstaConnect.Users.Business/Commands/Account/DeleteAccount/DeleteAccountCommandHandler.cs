using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Abstract;
using InstaConnect.Users.Data.Abstraction.Repositories;

namespace InstaConnect.Users.Business.Commands.Account.DeleteAccount;

public class DeleteAccountCommandHandler : ICommandHandler<DeleteAccountCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public DeleteAccountCommandHandler(
        IUnitOfWork unitOfWork,
        IUserRepository userRepository, 
        ICurrentUserContext currentUserContext)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Handle(DeleteAccountCommand request, CancellationToken cancellationToken)
    {
        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();
        var existingUser = await _userRepository.GetByIdAsync(currentUserDetails.Id, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        _userRepository.Delete(existingUser);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
