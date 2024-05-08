﻿using AutoMapper;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Entities;
using InstaConnect.Shared.Business.Exceptions.Base;
using InstaConnect.Shared.Business.Exceptions.PostComment;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Business.Models.Requests;
using InstaConnect.Shared.Business.Models.Responses;
using MassTransit;

namespace InstaConnect.Posts.Business.Commands.PostCommentLikes.AddPostCommentLike;

internal class AddPostCommentLikeCommandHandler : ICommandHandler<AddPostCommentLikeCommand>
{
    private const string POST_COMMENT_ALREADY_LIKED = "This user has already liked this comment";

    private readonly IMapper _mapper;
    private readonly IPostCommentRepository _postCommentRepository;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;
    private readonly IRequestClient<GetCurrentUserRequest> _getCurrentUserRequestClient;

    public AddPostCommentLikeCommandHandler(
        IMapper mapper,
        IPostCommentRepository postCommentRepository,
        IPostCommentLikeRepository postCommentLikeRepository,
        IRequestClient<GetCurrentUserRequest> getCurrentUserRequestClient)
    {
        _mapper = mapper;
        _postCommentRepository = postCommentRepository;
        _postCommentLikeRepository = postCommentLikeRepository;
        _getCurrentUserRequestClient = getCurrentUserRequestClient;
    }

    public async Task Handle(AddPostCommentLikeCommand request, CancellationToken cancellationToken)
    {
        var existingPostComment = _postCommentRepository.GetByIdAsync(request.PostCommentId, cancellationToken);

        if (existingPostComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var getCurrentUserRequest = _mapper.Map<GetCurrentUserRequest>(request);
        var getCurrentUserResponse = await _getCurrentUserRequestClient.GetResponse<GetCurrentUserResponse>(getCurrentUserRequest, cancellationToken);

        var existingPostLike = _postCommentLikeRepository.GetByUserIdAndPostCommentIdAsync(getCurrentUserResponse.Message.Id, request.PostCommentId, cancellationToken);

        if (existingPostLike == null)
        {
            throw new BadRequestException(POST_COMMENT_ALREADY_LIKED);
        }

        var postCommentLike = _mapper.Map<PostCommentLike>(request);
        _mapper.Map(getCurrentUserResponse.Message, postCommentLike);
        await _postCommentLikeRepository.AddAsync(postCommentLike, cancellationToken);
    }
}
