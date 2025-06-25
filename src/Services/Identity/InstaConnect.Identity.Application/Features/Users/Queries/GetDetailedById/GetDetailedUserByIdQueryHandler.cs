namespace InstaConnect.Identity.Application.Features.Users.Queries.GetDetailedById;

public class GetDetailedUserByIdQueryHandler : IQueryHandler<GetDetailedUserByIdQuery, UserDetailedQueryViewModel>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IUserReadRepository _userReadRepository;

    public GetDetailedUserByIdQueryHandler(
        IApplicationMapper applicationMapper,
        IUserReadRepository userReadRepository)
    {
        _applicationMapper = applicationMapper;
        _userReadRepository = userReadRepository;
    }

    public async Task<UserDetailedQueryViewModel> Handle(
        GetDetailedUserByIdQuery request,
        CancellationToken cancellationToken)
    {
        var existingUser = await _userReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var response = _applicationMapper.Map<UserDetailedQueryViewModel>(existingUser);

        return response;
    }
}
