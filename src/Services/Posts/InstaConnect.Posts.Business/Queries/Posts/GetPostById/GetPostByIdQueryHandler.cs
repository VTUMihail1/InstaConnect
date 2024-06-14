using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract;
using InstaConnect.Shared.Business.Exceptions.Posts;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.Posts.GetPostById;

internal class GetPostByIdQueryHandler : IQueryHandler<GetPostByIdQuery, PostViewDTO>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;

    public GetPostByIdQueryHandler(
        IMapper mapper,
        IPostRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    }

    public async Task<PostViewDTO> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(request.Id, cancellationToken);

        if (post == null)
        {
            throw new PostNotFoundException();
        }

        var postViewDTO = _mapper.Map<PostViewDTO>(post);

        return postViewDTO;
    }
}
