using InstaConnect.Users.Infrastructure.Features.Users.Models;

namespace InstaConnect.Users.Infrastructure.Features.Users.Utilities;

public static class UserQuerySql
{
    public const string GetAll = $@"SELECT 
                                       u.id AS {nameof(UserQueryEntity.Id)},
                                       u.first_name AS {nameof(UserQueryEntity.FirstName)},
                                       u.last_name AS {nameof(UserQueryEntity.LastName)},
                                       u.user_name AS {nameof(UserQueryEntity.Name)},
                                       u.email AS {nameof(UserQueryEntity.Email)},
                                       u.password_hash AS {nameof(UserQueryEntity.PasswordHash)},
                                       u.is_email_confirmed AS {nameof(UserQueryEntity.IsEmailConfirmed)},
                                       u.profile_image AS {nameof(UserQueryEntity.ProfileImage)},
                                       u.created_at AS {nameof(UserQueryEntity.CreatedAt)},
                                       u.updated_at AS {nameof(UserQueryEntity.UpdatedAt)},
                                   FROM users u
                                   WHERE u.{nameof(UserQueryEntity.Name)} = LIKE @{nameof(GetAllUsersQueryParameters.Name)}
                                     AND u.{nameof(UserQueryEntity.FirstName)} LIKE @{nameof(GetAllUsersQueryParameters.FirstName)}
                                     AND u.{nameof(UserQueryEntity.LastName)} LIKE @{nameof(GetAllUsersQueryParameters.LastName)}
                                   ORDER BY @{nameof(GetAllUsersQueryParameters.SortProperty)} @{nameof(GetAllUsersQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllUsersQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllUsersQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllTotalCount = $@"SELECT COUNT(*)
                                              FROM users u
                                              WHERE u.{nameof(UserQueryEntity.Name)} = LIKE @{nameof(GetAllUsersQueryParameters.Name)}
                                                AND u.{nameof(UserQueryEntity.FirstName)} LIKE @{nameof(GetAllUsersQueryParameters.FirstName)}
                                                AND u.{nameof(UserQueryEntity.LastName)} LIKE @{nameof(GetAllUsersQueryParameters.LastName)};";

    public const string GetById = $@"SELECT
                                       u.id AS {nameof(UserQueryEntity.Id)},
                                       u.first_name AS {nameof(UserQueryEntity.FirstName)},
                                       u.last_name AS {nameof(UserQueryEntity.LastName)},
                                       u.user_name AS {nameof(UserQueryEntity.Name)},
                                       u.email AS {nameof(UserQueryEntity.Email)},
                                       u.password_hash AS {nameof(UserQueryEntity.PasswordHash)},
                                       u.is_email_confirmed AS {nameof(UserQueryEntity.IsEmailConfirmed)},
                                       u.profile_image AS {nameof(UserQueryEntity.ProfileImage)},
                                       u.created_at AS {nameof(UserQueryEntity.CreatedAt)},
                                       u.updated_at AS {nameof(UserQueryEntity.UpdatedAt)},
                                   FROM users u
                                   WHERE u.{nameof(UserQueryEntity.Id)} = @{nameof(GetUserByIdQueryParameters.Id)};";

    public const string GetByName = $@"SELECT
                                       u.id AS {nameof(UserQueryEntity.Id)},
                                       u.first_name AS {nameof(UserQueryEntity.FirstName)},
                                       u.last_name AS {nameof(UserQueryEntity.LastName)},
                                       u.user_name AS {nameof(UserQueryEntity.Name)},
                                       u.email AS {nameof(UserQueryEntity.Email)},
                                       u.password_hash AS {nameof(UserQueryEntity.PasswordHash)},
                                       u.is_email_confirmed AS {nameof(UserQueryEntity.IsEmailConfirmed)},
                                       u.profile_image AS {nameof(UserQueryEntity.ProfileImage)},
                                       u.created_at AS {nameof(UserQueryEntity.CreatedAt)},
                                       u.updated_at AS {nameof(UserQueryEntity.UpdatedAt)},
                                   FROM users u
                                   WHERE u.{nameof(UserQueryEntity.Name)} = @{nameof(GetUserByNameQueryParameters.Name)};";

    public const string GetByEmail = $@"SELECT
                                       u.id AS {nameof(UserQueryEntity.Id)},
                                       u.first_name AS {nameof(UserQueryEntity.FirstName)},
                                       u.last_name AS {nameof(UserQueryEntity.LastName)},
                                       u.user_name AS {nameof(UserQueryEntity.Name)},
                                       u.email AS {nameof(UserQueryEntity.Email)},
                                       u.password_hash AS {nameof(UserQueryEntity.PasswordHash)},
                                       u.is_email_confirmed AS {nameof(UserQueryEntity.IsEmailConfirmed)},
                                       u.profile_image AS {nameof(UserQueryEntity.ProfileImage)},
                                       u.created_at AS {nameof(UserQueryEntity.CreatedAt)},
                                       u.updated_at AS {nameof(UserQueryEntity.UpdatedAt)},
                                   FROM users u
                                   WHERE u.{nameof(UserQueryEntity.Email)} = @{nameof(GetUserByEmailQueryParameters.Email)};";
}
