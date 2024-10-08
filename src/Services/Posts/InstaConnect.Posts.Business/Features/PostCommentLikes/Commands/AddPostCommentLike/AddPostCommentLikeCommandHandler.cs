﻿using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Models.Entitites;
using InstaConnect.Posts.Data.Features.PostComments.Abstract;
using InstaConnect.Posts.Data.Features.Users.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Base;
using InstaConnect.Shared.Common.Exceptions.PostComment;
using InstaConnect.Shared.Common.Exceptions.User;
using InstaConnect.Shared.Data.Abstractions;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Commands.AddPostCommentLike;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommand, PostCommentLikeCommandViewModel>
{
    private const string POST_COMMENT_ALREADY_LIKED = "This user has already liked this comment";

    private readonly IUnitOfWork _unitOfWork;
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IPostCommentWriteRepository _postCommentWriteRepository;
    private readonly IPostCommentLikeWriteRepository _postCommentLikeWriteRepository;

    public AddPostCommentLikeCommandHandler(
        IUnitOfWork unitOfWork,
        IInstaConnectMapper instaConnectMapper,
        IUserWriteRepository userWriteRepository,
        IPostCommentWriteRepository postCommentRepository,
        IPostCommentLikeWriteRepository postCommentLikeRepository)
    {
        _unitOfWork = unitOfWork;
        _instaConnectMapper = instaConnectMapper;
        _userWriteRepository = userWriteRepository;
        _postCommentWriteRepository = postCommentRepository;
        _postCommentLikeWriteRepository = postCommentLikeRepository;
    }

    public async Task<PostCommentLikeCommandViewModel> Handle(
        AddPostCommentLikeCommand request,
        CancellationToken cancellationToken)
    {
        var existingPostComment = await _postCommentWriteRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var existingUser = await _userWriteRepository.GetByIdAsync(request.CurrentUserId, cancellationToken);

        if (existingUser == null)
        {
            throw new UserNotFoundException();
        }

        var existingPostLike = await _postCommentLikeWriteRepository.GetByUserIdAndPostCommentIdAsync(request.CurrentUserId, request.PostCommentId, cancellationToken);

        if (existingPostLike != null)
        {
            throw new BadRequestException(POST_COMMENT_ALREADY_LIKED);
        }

        var postCommentLike = _instaConnectMapper.Map<PostCommentLike>(request);
        _postCommentLikeWriteRepository.Add(postCommentLike);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var postCommentLikeCommandViewModel = _instaConnectMapper.Map<PostCommentLikeCommandViewModel>(postCommentLike);

        return postCommentLikeCommandViewModel;
    }
}
