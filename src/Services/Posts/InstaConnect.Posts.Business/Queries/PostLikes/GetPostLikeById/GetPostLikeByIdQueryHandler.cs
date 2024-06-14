using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Exceptions.PostLike;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostLikes.GetPostLikeById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQuery, PostLikeViewDTO>
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

    public async Task<PostLikeViewDTO> Handle(GetPostLikeByIdQuery request, CancellationToken cancellationToken)
    {
        var postLike = await _postLikeRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var postLikeViewDTO = _mapper.Map<PostLikeViewDTO>(postLike);

        return postLikeViewDTO;
    }
}
