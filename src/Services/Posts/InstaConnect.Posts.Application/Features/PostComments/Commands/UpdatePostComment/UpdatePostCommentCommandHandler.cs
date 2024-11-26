using InstaConnect.Posts.Application.Features.PostComments.Models;
using InstaConnect.Posts.Domain.Features.PostComments.Abstract;
using InstaConnect.Shared.Application.Abstractions;
using InstaConnect.Shared.Common.Exceptions.PostComment;
using InstaConnect.Shared.Common.Exceptions.User;

namespace InstaConnect.Posts.Application.Features.PostComments.Commands.UpdatePostComment;

internal class UpdatePostCommentCommandHandler : ICommandHandler<UpdatePostCommentCommand, PostCommentCommandViewModel>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentWriteRepository _postCommentRepository;

    public UpdatePostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IPostCommentWriteRepository postCommentRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<PostCommentCommandViewModel> Handle(
        UpdatePostCommentCommand request,
        CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        if (request.CurrentUserId != existingPostComment.UserId)
        {
            throw new UserForbiddenException();
        }

        _instaConnectMapper.Map(request, existingPostComment);
        _postCommentRepository.Update(existingPostComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCommand = _instaConnectMapper.Map<PostCommentCommandViewModel>(existingPostComment);

        return postCommentCommand;
    }
}
