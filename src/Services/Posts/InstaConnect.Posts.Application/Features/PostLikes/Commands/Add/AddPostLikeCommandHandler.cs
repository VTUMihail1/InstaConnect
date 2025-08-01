using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;

internal class AddPostLikeCommandHandler : ICommandHandler<AddPostLikeCommandRequest, AddPostLikeCommandResponse>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IApplicationMapper _applicationMapper;

    public AddPostLikeCommandHandler(
        IPostLikeService postLikeService,
        IApplicationMapper applicationMapper)
    {
        _postLikeService = postLikeService;
        _applicationMapper = applicationMapper;
    }

    public async Task<AddPostLikeCommandResponse> Handle(AddPostLikeCommandRequest request, CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<AddPostLikeCommand>(request);
        var postLike = await _postLikeService.AddAsync(serviceRequest, cancellationToken);

        var response = _applicationMapper.Map<AddPostLikeCommandResponse>(postLike);

        return response;
    }
}
