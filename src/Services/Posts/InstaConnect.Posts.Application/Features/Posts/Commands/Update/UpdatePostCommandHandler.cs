using InstaConnect.Posts.Domain.Features.Posts.Models.Requests;

namespace InstaConnect.Posts.Application.Features.Posts.Commands.Update;

public class UpdatePostCommandHandler : ICommandHandler<UpdatePostCommandRequest, UpdatePostCommandResponse>
{
    private readonly IPostService _postService;
    private readonly IApplicationMapper _applicationMapper;

    public UpdatePostCommandHandler(
        IPostService postService,
        IApplicationMapper applicationMapper)
    {
        _postService = postService;
        _applicationMapper = applicationMapper;
    }

    public async Task<UpdatePostCommandResponse> Handle(
        UpdatePostCommandRequest request,
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<UpdatePostCommand>(request);
        var post = await _postService.UpdateAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<UpdatePostCommandResponse>(post);

        return response;
    }
}
