﻿using InstaConnect.Posts.Business.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Data.Features.PostCommentLikes.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Exceptions.PostCommentLike;

namespace InstaConnect.Posts.Business.Features.PostCommentLikes.Queries.GetPostCommentLikeById;

internal class GetPostCommentLikeByIdQueryHandler : IQueryHandler<GetPostCommentLikeByIdQuery, PostCommentLikeQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentLikeReadRepository _postCommentLikeRepository;

    public GetPostCommentLikeByIdQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostCommentLikeReadRepository postCommentLikeRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task<PostCommentLikeQueryViewModel> Handle(GetPostCommentLikeByIdQuery request, CancellationToken cancellationToken)
    {
        var postCommentLike = await _postCommentLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postCommentLike == null)
        {
            throw new PostCommentLikeNotFoundException();
        }

        var response = _instaConnectMapper.Map<PostCommentLikeQueryViewModel>(postCommentLike);

        return response;
    }
}
