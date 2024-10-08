﻿using InstaConnect.Posts.Business.Features.Posts.Models;
using InstaConnect.Posts.Data.Features.Posts.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Common.Exceptions.Posts;

namespace InstaConnect.Posts.Business.Features.Posts.Queries.GetPostById;

internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetPostByIdQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postReadRepository;
    }

    public async Task<PostQueryViewModel> Handle(
        GetPostByIdQuery request,
        CancellationToken cancellationToken)
    {
        var post = await _postReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        var response = _instaConnectMapper.Map<PostQueryViewModel>(post);

        return response;
    }
}
