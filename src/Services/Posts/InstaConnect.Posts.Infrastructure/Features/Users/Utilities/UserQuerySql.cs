using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Posts.Infrastructure.Features.Posts.Utilities;

public static class UserQuerySql
{
    public const string GetById = $@"SELECT
                                       u.id AS {nameof(UserQueryEntity.Id)},
                                       u.first_name AS {nameof(UserQueryEntity.FirstName)},
                                       u.last_name AS {nameof(UserQueryEntity.LastName)},
                                       u.user_name AS {nameof(UserQueryEntity.Name)},
                                       u.email AS {nameof(UserQueryEntity.Email)},
                                       u.profile_image AS {nameof(UserQueryEntity.ProfileImage)},
                                       u.created_at AS {nameof(UserQueryEntity.CreatedAt)},
                                       u.updated_at AS {nameof(UserQueryEntity.UpdatedAt)},
                                   FROM users u
                                   WHERE u.{nameof(UserQueryEntity.Id)} = @{nameof(GetUserByIdParameters.Id)};";
}
