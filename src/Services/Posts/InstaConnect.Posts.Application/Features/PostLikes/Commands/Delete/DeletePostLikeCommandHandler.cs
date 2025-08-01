using InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Add;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Abstractions;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Requests;

namespace InstaConnect.PostLikes.Application.Features.PostLikes.Commands.Delete;

internal class DeletePostLikeCommandHandler : ICommandHandler<DeletePostLikeCommandRequest>
{
    private readonly IPostLikeService _postLikeService;
    private readonly IApplicationMapper _applicationMapper;

    public DeletePostLikeCommandHandler(
        IPostLikeService postLikeService,
        IApplicationMapper applicationMapper)
    {
        _postLikeService = postLikeService;
        _applicationMapper = applicationMapper;
    }

    public async Task Handle(
        DeletePostLikeCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeletePostLikeCommand>(request);
        await _postLikeService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
