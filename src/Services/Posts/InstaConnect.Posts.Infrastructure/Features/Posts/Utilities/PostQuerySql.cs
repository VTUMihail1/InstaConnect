using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

public static class PostQuerySql
{
    public const string GetAll = $@"SELECT 
                                       p.id AS {nameof(Post.Id)},
                                       p.title AS {nameof(Post.Title)},
                                       p.content AS {nameof(Post.Content)},
                                       p.user_id AS {nameof(Post.UserId)},
                                       p.created_at AS {nameof(Post.CreatedAt)},
                                       p.updated_at AS {nameof(Post.UpdatedAt)},
                                       u.id AS {nameof(User.Id)},
                                       u.first_name AS {nameof(User.FirstName)},
                                       u.last_name AS {nameof(User.LastName)},
                                       u.user_name AS {nameof(User.UserName)},
                                       u.email AS {nameof(User.Email)},
                                       u.profile_image AS {nameof(User.ProfileImage)},
                                       u.created_at AS {nameof(User.CreatedAt)},
                                       u.updated_at AS {nameof(User.UpdatedAt)},
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

    public const string GetById = $@"SELECT TOP 1
                                       p.id AS {nameof(Post.Id)},
                                       p.title AS {nameof(Post.Title)},
                                       p.content AS {nameof(Post.Content)},
                                       p.user_id AS {nameof(Post.UserId)},
                                       p.created_at AS {nameof(Post.CreatedAt)},
                                       p.updated_at AS {nameof(Post.UpdatedAt)},
                                       u.id AS {nameof(User.Id)},
                                       u.first_name AS {nameof(User.FirstName)},
                                       u.last_name AS {nameof(User.LastName)},
                                       u.user_name AS {nameof(User.UserName)},
                                       u.email AS {nameof(User.Email)},
                                       u.profile_image AS {nameof(User.ProfileImage)},
                                       u.created_at AS {nameof(User.CreatedAt)},
                                       u.updated_at AS {nameof(User.UpdatedAt)},
                                   FROM posts p
                                   INNER JOIN users u ON p.{nameof(Post.UserId)} = u.{nameof(User.Id)}
                                   WHERE p.{nameof(Post.Id)} = @{nameof(GetPostByIdParameters.Id)};";
}
