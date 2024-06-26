using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Posts.Data.Read.Models.Filters;
using InstaConnect.Shared.Business.Abstractions;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetAllFilteredPostComments;

internal class GetAllFilteredPostCommentsQueryHandler : IQueryHandler<GetAllFilteredPostCommentsQuery, ICollection<PostCommentViewModel>>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentRepository _postCommentRepository;

    public GetAllFilteredPostCommentsQueryHandler(
        IMapper mapper,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<ICollection<PostCommentViewModel>> Handle(GetAllFilteredPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var filteredCollectionQuery = _mapper.Map<PostCommentFilteredCollectionQuery>(request);

        var postComments = await _postCommentRepository.GetAllFilteredAsync(filteredCollectionQuery, cancellationToken);
        var response = _mapper.Map<ICollection<PostCommentViewModel>>(postComments);

        return response;
    }
}
