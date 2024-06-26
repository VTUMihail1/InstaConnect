using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostLike;

namespace InstaConnect.Posts.Business.Read.Queries.PostLikes.GetPostLikeById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQuery, PostLikeViewModel>
{
    private readonly IMapper _mapper;
    private readonly IPostLikeRepository _postLikeRepository;

    public GetPostLikeByIdQueryHandler(
        IMapper mapper,
        IPostLikeRepository postLikeRepository)
    {
        _mapper = mapper;
        _postLikeRepository = postLikeRepository;
    }

    public async Task<PostLikeViewModel> Handle(GetPostLikeByIdQuery request, CancellationToken cancellationToken)
    {
        var postLike = await _postLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var response = _mapper.Map<PostLikeViewModel>(postLike);

        return response;
    }
}
