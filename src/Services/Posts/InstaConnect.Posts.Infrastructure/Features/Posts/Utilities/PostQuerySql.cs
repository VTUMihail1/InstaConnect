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
                                   INNER JOIN users u ON p.{nameof(Post.UserId)} = u.{nameof(User.Id)}
                                   WHERE p.{nameof(Post.UserId)} = @{nameof(GetAllQueryParameters.UserId)}
                                     AND u.{nameof(User.UserName)} LIKE @{nameof(GetAllQueryParameters.UserName)}
                                     AND p.{nameof(Post.Title)} LIKE @{nameof(GetAllQueryParameters.Title)}
                                   ORDER BY @{nameof(GetAllQueryParameters.SortProperty)} @{nameof(GetAllQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllTotalCount = $@"SELECT COUNT(*)
                                              FROM posts p
                                              INNER JOIN users u ON p.{nameof(Post.UserId)} = u.{nameof(User.Id)}
                                              WHERE p.{nameof(Post.UserId)} = @{nameof(GetAllQueryParameters.UserId)}
                                                AND u.{nameof(User.UserName)} LIKE @{nameof(GetAllQueryParameters.UserName)}
                                                AND p.{nameof(Post.Title)} LIKE @{nameof(GetAllQueryParameters.Title)};";

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
                                   INNER JOIN users u ON p.{nameof(Post.UserId)} = u.{nameof(User.Id)}
                                   WHERE p.{nameof(Post.Id)} = @{nameof(GetPostByIdParameters.Id)};";
}
