using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Read.Queries.PostLikes.GetAllFilteredPostLikes;

internal class GetAllFilteredPostLikesQueryHandler : IQueryHandler<GetAllFilteredPostLikesQuery, ICollection<PostLikeViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostLikeRepository _postLikeRepository;

    public GetAllFilteredPostLikesQueryHandler(
        IMapper mapper,
        IPostLikeRepository postLikeRepository)
    {
        _mapper = mapper;
        _postLikeRepository = postLikeRepository;
    }

    public async Task<ICollection<PostLikeViewModel>> Handle(GetAllFilteredPostLikesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostLikeFilteredCollectionQuery>(request);

        var postLikes = await _postLikeRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostLikeViewModel>>(postLikes);

        return response;
    }
}
