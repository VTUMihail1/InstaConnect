using AutoMapper;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Users.Business.Models;
using InstaConnect.Users.Data.Abstraction;

namespace InstaConnect.Users.Business.Queries.User.GetUser;

public class GetUserQueryHandler : IQueryHandler<GetUserQuery, UserViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;
    private readonly ICurrentUserContext _currentUserContext;

    public GetUserQueryHandler(
        IMapper mapper,
        IUserRepository userRepository,
        ICurrentUserContext currentUserContext)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _currentUserContext = currentUserContext;
    }

    public async Task<UserViewModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();
        var existingUser = await _userRepository.GetByIdAsync(currentUserDetails.Id, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _mapper.Map<UserViewModel>(existingUser);

        return response;
    }
}
