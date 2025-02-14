using InstaConnect.Identity.Application.Features.Users.Models;
using InstaConnect.Identity.Domain.Features.Users.Abstractions;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Abstractions;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Identity.Application.Features.Users.Queries.GetByName;

public class GetUserByNameQueryHandler : IQueryHandler<GetUserByNameQuery, UserQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetUserByNameQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IUserReadRepository userReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserQueryViewModel> Handle(
        GetUserByNameQuery request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userReadRepository.GetByNameAsync(request.UserName, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _instaConnectMapper.Map<UserQueryViewModel>(existingUser);

        return response;
    }
}
