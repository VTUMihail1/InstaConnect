﻿namespace InstaConnect.Posts.Application.Features.PostLikes.Queries.GetById;

internal class GetPostLikeByIdQueryHandler : IQueryHandler<GetPostLikeByIdQuery, PostLikeQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostLikeReadRepository _postLikeReadRepository;

    public GetPostLikeByIdQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostLikeReadRepository postLikeReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postLikeReadRepository = postLikeReadRepository;
    }

    public async Task<PostLikeQueryViewModel> Handle(
        GetPostLikeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var postLike = await _postLikeReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postLike == null)
        {
            throw new PostLikeNotFoundException();
        }

        var response = _instaConnectMapper.Map<PostLikeQueryViewModel>(postLike);

        return response;
    }
}
