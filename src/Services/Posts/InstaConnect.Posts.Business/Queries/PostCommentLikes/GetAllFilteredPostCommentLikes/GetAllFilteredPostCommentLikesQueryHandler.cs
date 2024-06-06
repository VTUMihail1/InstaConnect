using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

internal class GetAllFilteredPostCommentLikesQueryHandler : IQueryHandler<GetAllFilteredPostCommentLikesQuery, ICollection<PostCommentLikeViewDTO>>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public GetAllFilteredPostCommentLikesQueryHandler(
        IMapper mapper,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _mapper = mapper;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task<ICollection<PostCommentLikeViewDTO>> Handle(GetAllFilteredPostCommentLikesQuery request, CancellationToken cancellationToken)
    {
        var postCommentLikeFilteredCollectionQuery = _mapper.Map<PostCommentLikeFilteredCollectionQuery>(request);

        var postCommentLikes = await _postCommentLikeRepository.GetAllFilteredAsync(postCommentLikeFilteredCollectionQuery, cancellationToken);
        var postCommentLikeViewDTOs = _mapper.Map<ICollection<PostCommentLikeViewDTO>>(postCommentLikes);

        return postCommentLikeViewDTOs;
    }
}
