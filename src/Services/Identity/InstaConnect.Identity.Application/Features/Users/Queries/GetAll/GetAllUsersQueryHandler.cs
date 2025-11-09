namespace InstaConnect.Identity.Application.Features.Users.Queries.GetAll;

internal class GetAllUsersQueryHandler : IQueryHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public GetAllUsersQueryHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetAllUsersQueryResponse> Handle(
        GetAllUsersQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetAllUsersQuery>(request);
        var collection = await _userService.GetAllAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetAllUsersQueryResponse>(collection);

        return response;
    }
}
