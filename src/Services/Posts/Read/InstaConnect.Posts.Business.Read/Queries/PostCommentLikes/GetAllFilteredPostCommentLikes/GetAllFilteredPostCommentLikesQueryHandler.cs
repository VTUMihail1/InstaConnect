using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetAllFilteredPostCommentLikes;

internal class GetAllFilteredPostCommentLikesQueryHandler : IQueryHandler<GetAllFilteredPostCommentLikesQuery, ICollection<PostCommentLikeViewModel>>
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

    public async Task<ICollection<PostCommentLikeViewModel>> Handle(GetAllFilteredPostCommentLikesQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostCommentLikeFilteredCollectionQuery>(request);

        var postCommentLikes = await _postCommentLikeRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostCommentLikeViewModel>>(postCommentLikes);

        return response;
    }
}
