﻿using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllPosts;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, ICollection<PostViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public GetAllPostsQueryHandler(
        IMapper mapper,
        IPostRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<ICollection<PostViewModel>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);

        var posts = await _postRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostViewModel>>(posts);

        return response;
    }
}
