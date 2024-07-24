using AutoMapper;
using InstaConnect.Posts.Read.Business.Models;
using InstaConnect.Posts.Read.Data.Abstract;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.PostComment;

namespace InstaConnect.Posts.Read.Business.Queries.PostComments.GetPostCommentById;

internal class GetPostCommentByIdQueryHandler : IQueryHandler<GetPostCommentByIdQuery, PostCommentQueryViewModel>
{
    private readonly IInstaConnectMapper _instaConnectMapper;
    private readonly IPostCommentReadRepository _postCommentReadRepository;

    public GetPostCommentByIdQueryHandler(
        IInstaConnectMapper mapper,
        IPostCommentReadRepository postCommentRepository)
    {
        _instaConnectMapper = mapper;
        _postCommentReadRepository = postCommentRepository;
    }

    public async Task<PostCommentQueryViewModel> Handle(GetPostCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var postComment = await _postCommentReadRepository.GetByIdAsync(request.Id, cancellationToken);

        if (postComment == null)
        {
            throw new PostCommentNotFoundException();
        }

        var response = _instaConnectMapper.Map<PostCommentQueryViewModel>(postComment);

        return response;
    }
}
