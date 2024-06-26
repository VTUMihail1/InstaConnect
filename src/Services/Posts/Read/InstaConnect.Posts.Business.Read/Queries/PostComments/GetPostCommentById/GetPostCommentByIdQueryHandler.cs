using AutoMapper;
using InstaConnect.Posts.Business.Read.Models;
using InstaConnect.Posts.Data.Read.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostComment;

namespace InstaConnect.Posts.Business.Read.Queries.PostComments.GetPostCommentById;

internal class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQuery, PostCommentViewModel>
{
    private readonly IMapper _mapper;
    private readonly IPostCommentRepository _postCommentRepository;

    public GetPostCommentByIdQueryHandler(
        IMapper mapper,
        IPostCommentRepository postCommentRepository)
    {
        _mapper = mapper;
        _postCommentRepository = postCommentRepository;
    }

    public async Task<PostCommentViewModel> Handle(GetPostCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var response = _mapper.Map<PostCommentViewModel>(postComment);

        return response;
    }
}
