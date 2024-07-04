using AutoMapper;
using InstaConnect.Posts.Write.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Write.Business.Commands.PostComments.DeletePostComment;

internal class DeletePostCommentCommandHandler : ICommandHandler<DeletePostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IPostCommentRepository _postCommentRepository;

    public DeletePostCommentCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Handle(DeletePostCommentCommand request, CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        if (request.CurrentUserId != existingPostComment.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postCommentRepository.Delete(existingPostComment);

        var postCommentDeletedEvent = _mapper.Map<PostCommentDeletedEvent>(existingPostComment);
        await _publishEndpoint.Publish(postCommentDeletedEvent, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
