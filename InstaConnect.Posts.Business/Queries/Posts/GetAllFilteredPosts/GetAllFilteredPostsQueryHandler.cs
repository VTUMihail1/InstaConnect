using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaConnect.Posts.Business.Queries.Posts.GetAllFilteredPosts;

public class GetAllFilteredPostsQueryHandler : IQueryHandler<GetAllFilteredPostsQuery, ICollection<PostViewDTO>>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public GetAllFilteredPostsQueryHandler(
        IMapper mapper,
        IPostRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<ICollection<PostViewDTO>> Handle(GetAllFilteredPostsQuery request, CancellationToken cancellationToken)
    {
        var postFilteredCollectionQuery = _mapper.Map<PostFilteredCollectionQuery>(request);

        var posts = await _postRepository.GetAllFilteredAsync(postFilteredCollectionQuery, cancellationToken);
        var postViewDTOs = _mapper.Map<ICollection<PostViewDTO>>(posts);

        return postViewDTOs;
    }
}
