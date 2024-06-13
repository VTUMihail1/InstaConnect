using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment;

internal class DeletePostCommentCommandHandler : ICommandHandler<DeletePostCommentCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentRepository _postCommentRepository;

    public DeletePostCommentCommandHandler(
        IUnitOfWork unitOfWork,
        ICurrentUserContext currentUserContext, 
        IPostCommentRepository postCommentRepository)
    {
        _unitOfWork = unitOfWork;
        _currentUserContext = currentUserContext;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Handle(DeletePostCommentCommand request, CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        if (currentUserDetails.Id != existingPostComment.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postCommentRepository.Delete(existingPostComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
