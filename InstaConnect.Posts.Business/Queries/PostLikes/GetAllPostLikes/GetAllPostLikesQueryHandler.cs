using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Shared.Business.Messaging;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetAllPostLikes;

internal class GetAllPostLikesQueryHandler : IQueryHandler<GetAllPostLikesQuery, ICollection<PostLikeViewDTO>>
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

    public async Task<ICollection<PostLikeViewDTO>> Handle(GetAllPostLikesQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);

        var postLikes = await _postLikeRepository.GetAllAsync(collectionQuery, cancellationToken);
        var postLikeViewDTOs = _mapper.Map<ICollection<PostLikeViewDTO>>(postLikes);

        return postLikeViewDTOs;
    }
}
