using InstaConnect.Posts.Application.Features.Posts.Queries.GetById;
using InstaConnect.Users.Application.Features.Users.Queries.GetAll;
using InstaConnect.Users.Domain.Features.Users.Abstractions;

namespace InstaConnect.Users.Application.Features.Users.Queries.GetById;

internal class GetUserDetailsByIdQueryHandler : IQueryHandler<GetUserDetailsByIdQueryRequest, GetUserDetailsByIdQueryResponse>
{
    private readonly IUserService _userService;
    private readonly IApplicationMapper _applicationMapper;

    public GetUserDetailsByIdQueryHandler(
        IUserService userService,
        IApplicationMapper applicationMapper)
    {
        _userService = userService;
        _applicationMapper = applicationMapper;
    }

    public async Task<GetUserDetailsByIdQueryResponse> Handle(
        GetUserDetailsByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<GetUserByIdQuery>(request);
        var user = await _userService.GetByIdAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<GetUserDetailsByIdQueryResponse>(user);

        return response;
    }
}
