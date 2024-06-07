using AutoMapper;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Users.Data.Abstraction.Repositories;
using MassTransit;

namespace InstaConnect.Users.Business.Consumers;

public class GetCurrentUserConsumer : IConsumer<GetCurrentUserRequest>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public GetCurrentUserConsumer(
        IMapper mapper,
        IUserRepository userRepository,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task Consume(ConsumeContext<GetCurrentUserRequest> context)
    {
        var currentUserId = _currentUserContext.GetCurrentUserDetails();

        if (currentUserId == null)
        {
            throw new AccountUnauthorizedException();
        }

        var user = await _userRepository.GetByIdAsync(currentUserId, context.CancellationToken);

        if (user == null)
        {
            throw new UserNotFoundException();
        }

        var getCurrentUserResponse = _mapper.Map<CurrentUserDetails>(user);

        await context.RespondAsync(getCurrentUserResponse);
    }
}
