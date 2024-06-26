using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Data.Models.Filters;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllPostComments;

internal class GetAllPostCommentsQueryHandler : IQueryHandler<GetAllPostCommentsQuery, ICollection<PostCommentViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentRepository _postCommentRepository;

    public GetAllPostCommentsQueryHandler(
        IMapper mapper,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<ICollection<PostCommentViewModel>> Handle(GetAllPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var collectionQuery = _mapper.Map<CollectionQuery>(request);

        var postComments = await _postCommentRepository.GetAllAsync(collectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostCommentViewModel>>(postComments);

        return response;
    }
}
