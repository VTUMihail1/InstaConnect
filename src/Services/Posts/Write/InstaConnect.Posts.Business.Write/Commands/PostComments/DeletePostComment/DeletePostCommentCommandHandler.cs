using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostComments.DeletePostComment;

internal class DeletePostCommentCommandHandler : ICommandHandler<DeletePostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentRepository _postCommentRepository;

    public DeletePostCommentCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        ICurrentUserContext currentUserContext,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
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

        var postCommentDeletedEvent = _mapper.Map<PostCommentDeletedEvent>(existingPostComment);
        await _publishEndpoint.Publish(postCommentDeletedEvent, cancellationToken);
    }
}
