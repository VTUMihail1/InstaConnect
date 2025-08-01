using InstaConnect.PostComments.Infrastructure.Features.PostComments.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.PostComments.Infrastructure.Features.PostComments.Utilities;

public static class PostCommentQuerySql
{
    public const string GetAll = $@"SELECT 
                                       pc.id AS {nameof(PostCommentQueryEntity.Id)},
                                       pc.comment_id AS {nameof(PostCommentQueryEntity.CommentId)},
                                       pc.content AS {nameof(PostCommentQueryEntity.Content)},
                                       pc.user_id AS {nameof(PostCommentQueryEntity.UserId)},
                                       pc.created_at AS {nameof(PostCommentQueryEntity.CreatedAt)},
                                       pc.updated_at AS {nameof(PostCommentQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostCommentQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostCommentQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostCommentQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostCommentQueryEntity.UserName)},
                                       u.email AS {nameof(PostCommentQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostCommentQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostCommentQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostCommentQueryEntity.UserUpdatedAt)},
                                   FROM post_comments pp
                                   INNER JOIN users u ON pc.{nameof(PostCommentQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pc.{nameof(PostCommentQueryEntity.Id)} = {nameof(GetAllPostCommentsQueryParameters.Id)}
                                     AND pc.{nameof(PostCommentQueryEntity.UserId)} = @{nameof(GetAllPostCommentsQueryParameters.UserId)}
                                     AND u.{nameof(PostCommentQueryEntity.UserName)} LIKE @{nameof(GetAllPostCommentsQueryParameters.UserName)}
                                   ORDER BY @{nameof(GetAllPostCommentsQueryParameters.SortProperty)} @{nameof(GetAllPostCommentsQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllPostCommentsQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllPostCommentsQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllTotalCount = $@"SELECT COUNT(*)
                                              FROM post_comments pc
                                              INNER JOIN users u ON pc.{nameof(PostCommentQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                              WHERE pc.{nameof(PostCommentQueryEntity.Id)} = @{nameof(GetAllPostCommentsQueryParameters.Id)}
                                                AND pl.{nameof(PostCommentQueryEntity.UserId)} = @{nameof(GetAllPostCommentsQueryParameters.UserId)}
                                                AND u.{nameof(PostCommentQueryEntity.UserName)} LIKE @{nameof(GetAllPostCommentsQueryParameters.UserName)};";

    public const string GetById = $@"SELECT
                                       pc.id AS {nameof(PostCommentQueryEntity.Id)},
                                       pc.comment_id AS {nameof(PostCommentQueryEntity.CommentId)},
                                       pc.content AS {nameof(PostCommentQueryEntity.Content)},
                                       pc.user_id AS {nameof(PostCommentQueryEntity.UserId)},
                                       pc.created_at AS {nameof(PostCommentQueryEntity.CreatedAt)},
                                       pc.updated_at AS {nameof(PostCommentQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostCommentQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostCommentQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostCommentQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostCommentQueryEntity.UserName)},
                                       u.email AS {nameof(PostCommentQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostCommentQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostCommentQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostCommentQueryEntity.UserUpdatedAt)},
                                   FROM post_comments pc
                                   INNER JOIN users u ON pc.{nameof(PostCommentQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pc.{nameof(PostCommentQueryEntity.Id)} = @{nameof(GetPostCommentByIdQueryParameters.Id)}
                                     AND pc.{nameof(PostCommentQueryEntity.CommentId)} = @{nameof(GetPostCommentByIdQueryParameters.CommentId)};";
}
