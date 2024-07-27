using AutoMapper;
using InstaConnect.Posts.Business.Models.Post;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Posts;

namespace InstaConnect.Posts.Business.Queries.Posts.GetPostById;

internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostReadRepository _postReadRepository;

    public GetPostByIdQueryHandler(
        IInstaConnectMapper instaConnectMapper,
        IPostReadRepository postReadRepository)
    {
        _instaConnectMapper = instaConnectMapper;
        _postReadRepository = postReadRepository;
    }

    public async Task<PostQueryViewModel> Handle(
        GetPostByIdQuery request,
        CancellationToken cancellationToken)
    {
        var post = await _postReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        var response = _instaConnectMapper.Map<PostQueryViewModel>(post);

        return response;
    }
}
