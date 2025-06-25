namespace InstaConnect.Identity.Application.Features.Users.Queries.GetByName;

public class GetUserByNameQueryHandler : IQueryHandler<GetUserByNameQuery, UserQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetUserByNameQueryHandler(
        IApplicationMapper applicationMapper,
        IUserReadRepository userReadRepository)
    {
        _applicationMapper = applicationMapper;
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

        var response = _applicationMapper.Map<UserQueryViewModel>(existingUser);

        return response;
    }
}
