using AutoMapper;
using InstaConnect.Posts.Data.Write.Abstract;
using InstaConnect.Posts.Data.Write.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Contracts.PostCommentLikes;
using InstaConnect.Shared.Business.Contracts.Users;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Exceptions.User;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Write.Commands.PostCommentLikes.AddPostCommentLike;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommand>
{
    private const string POST_COMMENT_ALREADY_LIKED = "This user has already liked this comment";

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;
    private readonly IRequestClient<GetUserByIdRequest> _getUserByIdRequestClient;

    public AddPostCommentLikeCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        IPublishEndpoint publishEndpoint,
        IPostCommentRepository postCommentRepository,
        IPostCommentLikeRepository postCommentLikeRepository,
        IRequestClient<GetUserByIdRequest> getUserByIdRequestClient)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publishEndpoint = publishEndpoint;
        _postCommentRepository = postCommentRepository;
        _postCommentLikeRepository = postCommentLikeRepository;
        _getUserByIdRequestClient = getUserByIdRequestClient;
    }

    public async Task Handle(AddPostCommentLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var getUserByIdRequest = _mapper.Map<GetUserByIdRequest>(request);
        var getUserByIdResponse = await _getUserByIdRequestClient.GetResponse<GetUserByIdResponse>(getUserByIdRequest, cancellationToken);

        if (getUserByIdResponse == null)
        {
            throw new UserNotFoundException();
        }

        var existingPostLike = await _postCommentLikeRepository.GetByUserIdAndPostCommentIdAsync(request.CurrentUserId, request.PostCommentId, cancellationToken);

        if (existingPostLike == null)
        {
            throw new BadRequestException(POST_COMMENT_ALREADY_LIKED);
        }

        var postCommentLike = _mapper.Map<PostCommentLike>(request);
        _postCommentLikeRepository.Add(postCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentLikeCreatedEvent = _mapper.Map<PostCommentLikeCreatedEvent>(postCommentLike);
        await _publishEndpoint.Publish(postCommentLikeCreatedEvent, cancellationToken);
    }
}
