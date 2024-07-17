using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.PostLikes.GetAllPostLikes;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQuery, ICollection<PostLikeViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostLikeRepository _postLikeRepository;

    public GetAllPostLikesQueryHandler(
        IMapper mapper,
        IPostLikeRepository postLikeRepository)
    {
        _mapper = mapper;
        _postLikeRepository = postLikeRepository;
    }

    public async Task<ICollection<PostLikeViewModel>> Handle(GetAllPostLikesQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionReadQuery>(request);

        var postLikes = await _postLikeRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostLikeViewModel>>(postLikes);

        return response;
    }
}
