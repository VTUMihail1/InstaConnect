using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Users.Data.Abstraction.Repositories;
using MassTransit;

namespace InstaConnect.Users.Business.Consumers;

public class ValidateUserByIdConsumer : IConsumer<ValidateUserByIdRequest>
{
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public ValidateUserByIdConsumer(
        IUserRepository userRepository,
        ICurrentUserContext currentUserContext)
    {
        _userRepository = userRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Consume(ConsumeContext<ValidateUserByIdRequest> context)
    {
        var currentUserId = _currentUserContext.GetUsedId();

        if (currentUserId == null)
        {
            throw new AccountUnauthorizedException();
        }

        var existingUser = await _userRepository.GetByIdAsync(context.Message.Id, context.CancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        if (currentUserId != existingUser.Id)
        {
            throw new AccountForbiddenException();
        }
    }
}
