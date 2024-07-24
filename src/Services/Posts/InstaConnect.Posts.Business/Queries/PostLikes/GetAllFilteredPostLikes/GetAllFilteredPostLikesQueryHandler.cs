using AutoMapper;
using InstaConnect.Posts.Data.Models.Filters.PostLikes;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllFilteredPostLikes;

internal class GetAllFilteredPostLikesQueryHandler : IQueryHandler<GetAllFilteredPostLikesQuery, ICollection<PostLikeQueryViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostLikeReadRepository _postLikeRepository;

    public GetAllFilteredPostLikesQueryHandler(
        IMapper mapper,
        IPostLikeReadRepository postLikeRepository)
    {
        _mapper = mapper;
        _postLikeRepository = postLikeRepository;
    }

    public async Task<ICollection<PostLikeQueryViewModel>> Handle(GetAllFilteredPostLikesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostLikeFilteredCollectionReadQuery>(request);

        var postLikes = await _postLikeRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostLikeQueryViewModel>>(postLikes);

        return response;
    }
}
