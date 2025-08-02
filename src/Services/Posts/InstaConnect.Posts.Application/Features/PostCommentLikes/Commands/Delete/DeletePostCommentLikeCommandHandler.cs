using InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Add;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Abstractions;
using InstaConnect.PostCommentLikes.Domain.Features.PostCommentLikes.Models.Requests;

namespace InstaConnect.PostCommentLikes.Application.Features.PostCommentLikes.Commands.Delete;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentLikeService _postCommentLikeService;

    public DeletePostCommentLikeCommandHandler(
        IApplicationMapper applicationMapper,
        IPostCommentLikeService postCommentLikeService)
    {
        _applicationMapper = applicationMapper;
        _postCommentLikeService = postCommentLikeService;
    }

    public async Task Handle(
        DeletePostCommentLikeCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeletePostCommentLikeCommand>(request);
        await _postCommentLikeService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
