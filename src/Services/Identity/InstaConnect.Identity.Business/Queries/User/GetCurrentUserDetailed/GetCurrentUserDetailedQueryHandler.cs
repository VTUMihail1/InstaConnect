using AutoMapper;
using InstaConnect.Identity.Business.Models;
using InstaConnect.Identity.Data.Abstraction;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.User;

namespace InstaConnect.Identity.Business.Queries.User.GetCurrentUserDetailed;

public class GetCurrentUserDetailedQueryHandler : IQueryHandler<GetCurrentUserDetailedQuery, UserDetailedViewModel>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetCurrentUserDetailedQueryHandler(
        IMapper mapper,
        IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDetailedViewModel> Handle(GetCurrentUserDetailedQuery request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _mapper.Map<UserDetailedViewModel>(existingUser);

        return response;
    }
}
