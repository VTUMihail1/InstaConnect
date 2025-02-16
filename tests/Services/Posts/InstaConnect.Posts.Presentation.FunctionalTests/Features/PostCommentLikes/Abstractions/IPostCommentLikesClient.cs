using System.Net;

using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostCommentLikes.Models.Responses;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostCommentLikes.Abstractions;
public interface IPostCommentLikesClient
{
    Task<PostCommentLikeCommandResponse> AddAsync(AddPostCommentLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddPostCommentLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(AddPostCommentLikeRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeletePostCommentLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeletePostCommentLikeRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeletePostCommentLikeRequest request, CancellationToken cancellationToken);
    Task<PostCommentLikePaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<PostCommentLikePaginationQueryResponse> GetAllAsync(GetAllPostCommentLikesRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllPostCommentLikesRequest request, CancellationToken cancellationToken);
    Task<PostCommentLikeQueryResponse> GetByIdAsync(GetPostCommentLikeByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetPostCommentLikeByIdRequest request, CancellationToken cancellationToken);
}