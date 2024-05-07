using AutoMapper;
using InstaConnect.Posts.Business.Models;
using InstaConnect.Posts.Data.Abstract.Repositories;
using InstaConnect.Posts.Data.Models.Filters;
using InstaConnect.Shared.Business.Messaging;

namespace InstaConnect.Posts.Business.Queries.PostComments.GetAllFilteredPostComments;

public class GetAllFilteredPostCommentsQueryHandler : IQueryHandler<GetAllFilteredPostCommentsQuery, ICollection<PostCommentViewDTO>>
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

    public async Task<ICollection<PostCommentViewDTO>> Handle(GetAllFilteredPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var postCommentFilteredCollectionQuery = _mapper.Map<PostCommentFilteredCollectionQuery>(request);

        var postComments = await _postCommentRepository.GetAllFilteredAsync(postCommentFilteredCollectionQuery, cancellationToken);
        var postCommentViewDTOs = _mapper.Map<ICollection<PostCommentViewDTO>>(postComments);

        return postCommentViewDTOs;
    }
}
