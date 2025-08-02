using InstaConnect.PostComments.Application.Features.PostComments.Commands.Add;
using InstaConnect.PostComments.Domain.Features.PostComments.Abstractions;
using InstaConnect.PostComments.Domain.Features.PostComments.Models.Requests;

namespace InstaConnect.PostComments.Application.Features.PostComments.Commands.Delete;

internal class DeletePostCommentCommandHandler : ICommandHandler<DeletePostCommentCommandRequest>
{
    private readonly IApplicationMapper _applicationMapper;
    private readonly IPostCommentService _postCommentService;

    public DeletePostCommentCommandHandler(
        IApplicationMapper applicationMapper,
        IPostCommentService postCommentService)
    {
        _applicationMapper = applicationMapper;
        _postCommentService = postCommentService;
    }

    public async Task Handle(
        DeletePostCommentCommandRequest request, 
        CancellationToken cancellationToken)
    {
        var serviceRequest = _applicationMapper.Map<DeletePostCommentCommand>(request);
        await _postCommentService.DeleteAsync(serviceRequest, cancellationToken);
    }
}
