using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostCommentLikes;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Business.Exceptions.Account;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;
using MassTransit.Testing;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.DeletePostCommentLike;

internal class DeletePostCommentLikeCommandHandler : ICommandHandler<DeletePostCommentLikeCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public DeletePostCommentLikeCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        ICurrentUserContext currentUserContext,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _currentUserContext = currentUserContext;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task Handle(DeletePostCommentLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostCommentLike = await _postCommentLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (existingPostCommentLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUser();

        if (currentUserDetails.Id != existingPostCommentLike.UserId)
        {
            throw new AccountForbiddenException();
        }

        _postCommentLikeRepository.Delete(existingPostCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentLikeDeletedEvent = _mapper.Map<PostCommentLikeDeletedEvent>(currentUserDetails);
        await _publishEndpoint.Publish(postCommentLikeDeletedEvent, cancellationToken);
    }
}
