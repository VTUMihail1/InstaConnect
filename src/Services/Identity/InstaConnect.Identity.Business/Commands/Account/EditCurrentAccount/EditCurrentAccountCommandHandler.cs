using AutoMapper;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Identity.Business.Commands.Account.EditAccount;

public class EditCurrentAccountCommandHandler : ICommandHandler<EditCurrentAccountCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IPublishEndpoint _publishEndpoint;

    public EditCurrentAccountCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IUserRepository userRepository,
        IPublishEndpoint publishEndpoint)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Handle(EditCurrentAccountCommand request, CancellationToken cancellationToken)
    {
        var existingUserById = await _userRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUserById == null)
        {
            throw new UserNotFoundException();
        }

        var existingUserByName = await _userRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingUserById.UserName != request.UserName && existingUserByName != null)
        {
            throw new AccountUsernameAlreadyTakenException();
        }

        _mapper.Map(request, existingUserById);
        _userRepository.Update(existingUserById);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var userUpdatedEvent = _mapper.Map<UserUpdatedEvent>(existingUserById);
        await _publishEndpoint.Publish(userUpdatedEvent);
    }
}
