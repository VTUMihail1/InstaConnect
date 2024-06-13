using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Helpers;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using InstaConnect.Shared.Data.Abstract;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommand>
{
    private const string POST_COMMENT_ALREADY_LIKED = "This user has already liked this comment";

    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUserContext _currentUserContext;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public AddPostCommentLikeCommandHandler(
        IMapper mapper,
        IUnitOfWork unitOfWork,
        ICurrentUserContext currentUserContext,
        IPostCommentRepository postCommentRepository,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _currentUserContext = currentUserContext;
        _postCommentRepository = postCommentRepository;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task Handle(AddPostCommentLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var currentUserDetails = _currentUserContext.GetCurrentUserDetails();

        var existingPostLike = await _postCommentLikeRepository.GetByUserIdAndPostCommentIdAsync(currentUserDetails.Id!, request.PostCommentId, cancellationToken);

        if (existingPostLike == null)
        {
            throw new BadRequestException(POST_COMMENT_ALREADY_LIKED);
        }

        var postCommentLike = _mapper.Map<PostCommentLike>(request);
        _mapper.Map(currentUserDetails, postCommentLike);
        _postCommentLikeRepository.Add(postCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
