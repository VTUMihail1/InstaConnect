using System.Net;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Requests;
using InstaConnect.Posts.Presentation.Features.PostComments.Models.Responses;

namespace InstaConnect.Posts.Presentation.FunctionalTests.Features.PostComments.Abstractions;
public interface IPostCommentsClient
{
    Task<PostCommentCommandResponse> AddAsync(AddPostCommentRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddPostCommentRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(AddPostCommentRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeletePostCommentRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeletePostCommentRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeletePostCommentRequest request, CancellationToken cancellationToken);
    Task<PostCommentPaginationQueryResponse> GetAllAsync(CancellationToken cancellationToken);
    Task<PostCommentPaginationQueryResponse> GetAllAsync(GetAllPostCommentsRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllPostCommentsRequest request, CancellationToken cancellationToken);
    Task<PostCommentQueryResponse> GetByIdAsync(GetPostCommentByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetPostCommentByIdRequest request, CancellationToken cancellationToken);
    Task<PostCommentCommandResponse> UpdateAsync(UpdatePostCommentRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeAsync(UpdatePostCommentRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeUnauthorizedAsync(UpdatePostCommentRequest request, CancellationToken cancellationToken);
}