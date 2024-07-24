using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.Posts.GetAllPosts;

internal class GetAllPostsQueryHandler : IQueryHandler<GetAllPostsQuery, ICollection<PostQueryViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostReadRepository _postRepository;

    public GetAllPostsQueryHandler(
        IMapper mapper,
        IPostReadRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<ICollection<PostQueryViewModel>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionReadQuery>(request);

        var posts = await _postRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostQueryViewModel>>(posts);

        return response;
    }
}
