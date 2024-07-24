using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostLike;

namespace InstaConnect.Posts.Read.Business.Queries.PostLikes.GetPostLikeById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQuery, PostLikeQueryViewModel>
{
    private readonly IMapper _mapper;
    private readonly IPostLikeReadRepository _postLikeRepository;

    public GetPostLikeByIdQueryHandler(
        IMapper mapper,
        IPostLikeReadRepository postLikeRepository)
    {
        _mapper = mapper;
        _postLikeRepository = postLikeRepository;
    }

    public async Task<PostLikeQueryViewModel> Handle(GetPostLikeByIdQuery request, CancellationToken cancellationToken)
    {
        var postLike = await _postLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var response = _mapper.Map<PostLikeQueryViewModel>(postLike);

        return response;
    }
}
