using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostCommentLike;

namespace InstaConnect.Posts.Business.Read.Queries.PostCommentLikes.GetPostCommentLikeById;

internal class GetPostCommentLikeByIdQueryHandler : IQueryHandler<GetPostCommentLikeByIdQuery, PostCommentLikeViewModel>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentLikeRepository _postCommentLikeRepository;

    public GetPostCommentLikeByIdQueryHandler(
        IMapper mapper,
        IPostCommentLikeRepository postCommentLikeRepository)
    {
        _mapper = mapper;
        _postCommentLikeRepository = postCommentLikeRepository;
    }

    public async Task<PostCommentLikeViewModel> Handle(GetPostCommentLikeByIdQuery request, CancellationToken cancellationToken)
    {
        var postCommentLike = await _postCommentLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postCommentLike == null)
        {
            throw new PostCommentLikeNotFoundException();
        }

        var response = _mapper.Map<PostCommentLikeViewModel>(postCommentLike);

        return response;
    }
}
