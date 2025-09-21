using InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.PostCommentLikes.Infrastructure.Features.PostCommentLikes.Utilities;

public static class PostCommentLikeQuerySql
{
    public const string GetAll = $@"SELECT 
                                       pcl.id AS {nameof(PostCommentLikeQueryEntity.Id)},
                                       pcl.comment_id AS {nameof(PostCommentLikeQueryEntity.CommentId)},
                                       pcl.user_id AS {nameof(PostCommentLikeQueryEntity.UserId)},
                                       pcl.created_at AS {nameof(PostCommentLikeQueryEntity.CreatedAt)},
                                       pcl.updated_at AS {nameof(PostCommentLikeQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostCommentLikeQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostCommentLikeQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostCommentLikeQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostCommentLikeQueryEntity.UserName)},
                                       u.email AS {nameof(PostCommentLikeQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostCommentLikeQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostCommentLikeQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostCommentLikeQueryEntity.UserUpdatedAt)},
                                   FROM post_comment_likes pcl
                                   INNER JOIN users u ON pcl.{nameof(PostCommentLikeQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pcl.{nameof(PostCommentLikeQueryEntity.Id)} = @{nameof(GetAllPostCommentLikesQueryParameters.Id)}
                                     AND pcl.{nameof(PostCommentLikeQueryEntity.CommentId)} = @{nameof(GetAllPostCommentLikesQueryParameters.CommentId)}
                                     AND u.{nameof(PostCommentLikeQueryEntity.UserName)} LIKE @{nameof(GetAllPostCommentLikesQueryParameters.UserName)}
                                   ORDER BY @{nameof(GetAllPostCommentLikesQueryParameters.SortProperty)} @{nameof(GetAllPostCommentLikesQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllPostCommentLikesQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllPostCommentLikesQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllTotalCount = $@"SELECT COUNT(*)
                                              FROM post_comment_likes pcl
                                              INNER JOIN users u ON pcl.{nameof(PostCommentLikeQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                              WHERE pcl.{nameof(PostCommentLikeQueryEntity.Id)} = @{nameof(GetAllPostCommentLikesTotalCountQueryParameters.Id)}
                                                AND pcl.{nameof(PostCommentLikeQueryEntity.CommentId)} = @{nameof(GetAllPostCommentLikesTotalCountQueryParameters.CommentId)}
                                                AND u.{nameof(PostCommentLikeQueryEntity.UserName)} LIKE @{nameof(GetAllPostCommentLikesTotalCountQueryParameters.UserName)};";

    public const string GetById = $@"SELECT
                                       pcl.id AS {nameof(PostCommentLikeQueryEntity.Id)},
                                       pcl.comment_id AS {nameof(PostCommentLikeQueryEntity.CommentId)},
                                       pcl.user_id AS {nameof(PostCommentLikeQueryEntity.UserId)},
                                       pcl.created_at AS {nameof(PostCommentLikeQueryEntity.CreatedAt)},
                                       pcl.updated_at AS {nameof(PostCommentLikeQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostCommentLikeQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostCommentLikeQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostCommentLikeQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostCommentLikeQueryEntity.UserName)},
                                       u.email AS {nameof(PostCommentLikeQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostCommentLikeQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostCommentLikeQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostCommentLikeQueryEntity.UserUpdatedAt)},
                                   FROM post_comment_likes pcl
                                   INNER JOIN users u ON pcl.{nameof(PostCommentLikeQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pcl.{nameof(PostCommentLikeQueryEntity.Id)} = @{nameof(GetPostCommentLikeByIdQueryParameters.Id)}
                                     AND pcl.{nameof(PostCommentLikeQueryEntity.CommentId)} = @{nameof(GetPostCommentLikeByIdQueryParameters.CommentId)}
                                     AND pcl.{nameof(PostCommentLikeQueryEntity.UserId)} = @{nameof(GetPostCommentLikeByIdQueryParameters.UserId)};";
}
