using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Read.Business.Queries.PostCommentLikes.GetAllPostCommentLikes;

internal class GetAllPostCommentLikesQueryHandler : IQueryHandler<GetAllPostCommentLikesQuery, ICollection<PostCommentLikeViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public GetAllPostCommentLikesQueryHandler(
        IMapper mapper,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _mapper = mapper;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task<ICollection<PostCommentLikeViewModel>> Handle(GetAllPostCommentLikesQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionReadQuery>(request);

        var postCommentLikes = await _postCommentLikeRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostCommentLikeViewModel>>(postCommentLikes);

        return response;
    }
}
