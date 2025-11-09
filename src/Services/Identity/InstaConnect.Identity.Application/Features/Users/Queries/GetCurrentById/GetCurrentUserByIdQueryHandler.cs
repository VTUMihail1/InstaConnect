namespace InstaConnect.Identity.Application.Features.Users.Queries.GetCurrentById;

internal class GetCurrentUserByIdQueryHandler : IQueryHandler<GetCurrentUserByIdQueryRequest, GetCurrentUserByIdQueryResponse>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public GetCurrentUserByIdQueryHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetCurrentUserByIdQueryResponse> Handle(
        GetCurrentUserByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetUserByIdQuery>(request);
        var user = await _userService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetCurrentUserByIdQueryResponse>(user);

        return response;
    }
}
