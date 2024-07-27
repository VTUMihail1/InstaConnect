﻿using AutoMapper;
using InstaConnect.Posts.Business.Models.PostCommentLike;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostCommentLike;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetPostCommentLikeById;

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
