using InstaConnect.PostComments.Application.Features.PostComments.Models;
using InstaConnect.PostComments.Application.Features.PostComments.Queries.GetById;

namespace InstaConnect.PostComments.Application.Features.PostComments.Queries.GetAll;

public record GetPostCommentByIdApiResponse(PostCommentApiResponse Data);
