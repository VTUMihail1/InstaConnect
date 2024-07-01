using AutoMapper;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostComments;
using InstaConnect.Shared.Business.Contracts.Posts;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostComments.AddPostComment;

internal class AddPostCommentCommandHandler : ICommandHandler<AddPostCommentCommand>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPostRepository _postRepository;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentRepository _postCommentRepository;

    public AddPostCommentCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPostRepository postRepository,
        IPublishEndpoint publishEndpoint,
        ICurrentUserContext currentUserContext,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _postRepository = postRepository;
        _publishEndpoint = publishEndpoint;
        _currentUserContext = currentUserContext;
        _postCommentRepository = postCommentRepository;
    }

    public async Task Handle(AddPostCommentCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.PostId, cancellationToken);

        if (existingPost == null)
        {
            throw new PostNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUser();
        var postComment = _mapper.Map<PostComment>(request);
        _mapper.Map(currentUserDetails, postComment);
        _postCommentRepository.Add(postComment);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentCreatedEvent = _mapper.Map<PostCommentCreatedEvent>(postComment);
        await _publishEndpoint.Publish(postCommentCreatedEvent, cancellationToken);
    }
}
