using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

public static class PostQuerySql
{
    public const string GetAll = $@"SELECT 
                                       p.id AS {nameof(PostQueryEntity.Id)},
                                       p.title AS {nameof(PostQueryEntity.Title)},
                                       p.content AS {nameof(PostQueryEntity.Content)},
                                       p.user_id AS {nameof(PostQueryEntity.UserId)},
                                       p.created_at AS {nameof(PostQueryEntity.CreatedAt)},
                                       p.updated_at AS {nameof(PostQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostQueryEntity.UserName)},
                                       u.email AS {nameof(PostQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostQueryEntity.UserUpdatedAt)},
                                   FROM posts p
                                   INNER JOIN users u ON p.{nameof(PostQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE p.{nameof(PostQueryEntity.UserId)} = @{nameof(GetAllPostsQueryParameters.UserId)}
                                     AND u.{nameof(PostQueryEntity.UserName)} LIKE @{nameof(GetAllPostsQueryParameters.UserName)}
                                     AND p.{nameof(PostQueryEntity.Title)} LIKE @{nameof(GetAllPostsQueryParameters.Title)}
                                   ORDER BY @{nameof(GetAllPostsQueryParameters.SortProperty)} @{nameof(GetAllPostsQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllPostsQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllPostsQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllTotalCount = $@"SELECT COUNT(*)
                                              FROM posts p
                                              INNER JOIN users u ON p.{nameof(PostQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                              WHERE p.{nameof(PostQueryEntity.UserId)} = @{nameof(GetAllPostsTotalCountQueryParameters.UserId)}
                                                AND u.{nameof(PostQueryEntity.UserName)} LIKE @{nameof(GetAllPostsTotalCountQueryParameters.UserName)}
                                                AND p.{nameof(PostQueryEntity.Title)} LIKE @{nameof(GetAllPostsTotalCountQueryParameters.Title)};";

    public const string GetById = $@"SELECT
                                       p.id AS {nameof(PostQueryEntity.Id)},
                                       p.title AS {nameof(PostQueryEntity.Title)},
                                       p.content AS {nameof(PostQueryEntity.Content)},
                                       p.user_id AS {nameof(PostQueryEntity.UserId)},
                                       p.created_at AS {nameof(PostQueryEntity.CreatedAt)},
                                       p.updated_at AS {nameof(PostQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostQueryEntity.UserName)},
                                       u.email AS {nameof(PostQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostQueryEntity.UserUpdatedAt)},
                                   FROM posts p
                                   INNER JOIN users u ON p.{nameof(PostQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE p.{nameof(PostQueryEntity.Id)} = @{nameof(GetPostByIdQueryParameters.Id)};";
}
