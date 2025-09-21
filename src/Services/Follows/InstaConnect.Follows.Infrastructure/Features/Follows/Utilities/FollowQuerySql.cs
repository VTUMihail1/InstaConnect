using InstaConnect.Follows.Infrastructure.Features.Follows.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Follows.Infrastructure.Features.Follows.Utilities;

public static class FollowQuerySql
{
    public const string GetAllByFollower = $@"SELECT 
                                       pl.created_at AS {nameof(FollowQueryEntity.CreatedAt)},
                                       pl.updated_at AS {nameof(FollowQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(FollowQueryEntity.FollowerId)},
                                       u.first_name AS {nameof(FollowQueryEntity.FollowerFirstName)},
                                       u.last_name AS {nameof(FollowQueryEntity.FollowerLastName)},
                                       u.user_name AS {nameof(FollowQueryEntity.FollowerName)},
                                       u.email AS {nameof(FollowQueryEntity.FollowerEmail)},
                                       u.profile_image AS {nameof(FollowQueryEntity.FollowerProfileImage)},
                                       u.created_at AS {nameof(FollowQueryEntity.FollowerCreatedAt)},
                                       u.updated_at AS {nameof(FollowQueryEntity.FollowerUpdatedAt)},
                                       f.id AS {nameof(FollowQueryEntity.FollowingId)},
                                       f.first_name AS {nameof(FollowQueryEntity.FollowingFirstName)},
                                       f.last_name AS {nameof(FollowQueryEntity.FollowingLastName)},
                                       f.user_name AS {nameof(FollowQueryEntity.FollowingName)},
                                       f.email AS {nameof(FollowQueryEntity.FollowingEmail)},
                                       f.profile_image AS {nameof(FollowQueryEntity.FollowingProfileImage)},
                                       f.created_at AS {nameof(FollowQueryEntity.FollowingCreatedAt)},
                                       f.updated_at AS {nameof(FollowQueryEntity.FollowingUpdatedAt)},
                                   FROM follows pl
                                   INNER JOIN users u ON pl.{nameof(FollowQueryEntity.FollowerId)} = u.{nameof(UserQueryEntity.Id)}
                                   INNER JOIN users f ON pl.{nameof(FollowQueryEntity.FollowingId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pl.{nameof(FollowQueryEntity.FollowerId)} = {nameof(GetAllFollowsByFollowerQueryParameters.FollowerId)}
                                     AND pl.{nameof(FollowQueryEntity.FollowingName)} = @{nameof(GetAllFollowsByFollowerQueryParameters.FollowingName)}
                                   ORDER BY @{nameof(GetAllFollowsByFollowerQueryParameters.SortProperty)} @{nameof(GetAllFollowsByFollowerQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllFollowsByFollowerQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllFollowsByFollowerQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllByFollowerTotalCount = $@"SELECT COUNT(*)
                                              FROM follows pl
                                              INNER JOIN users u ON pl.{nameof(FollowQueryEntity.FollowerId)} = u.{nameof(UserQueryEntity.Id)}
                                              INNER JOIN users f ON pl.{nameof(FollowQueryEntity.FollowingId)} = u.{nameof(UserQueryEntity.Id)}
                                              WHERE pl.{nameof(FollowQueryEntity.FollowerId)} = @{nameof(GetAllFollowsByFollowerTotalCountQueryParameters.FollowerId)}
                                                AND pl.{nameof(FollowQueryEntity.FollowingName)} = @{nameof(GetAllFollowsByFollowerTotalCountQueryParameters.FollowingName)};";

    public const string GetAllByFollowing = $@"SELECT 
                                       pl.created_at AS {nameof(FollowQueryEntity.CreatedAt)},
                                       pl.updated_at AS {nameof(FollowQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(FollowQueryEntity.FollowerId)},
                                       u.first_name AS {nameof(FollowQueryEntity.FollowerFirstName)},
                                       u.last_name AS {nameof(FollowQueryEntity.FollowerLastName)},
                                       u.user_name AS {nameof(FollowQueryEntity.FollowerName)},
                                       u.email AS {nameof(FollowQueryEntity.FollowerEmail)},
                                       u.profile_image AS {nameof(FollowQueryEntity.FollowerProfileImage)},
                                       u.created_at AS {nameof(FollowQueryEntity.FollowerCreatedAt)},
                                       u.updated_at AS {nameof(FollowQueryEntity.FollowerUpdatedAt)},
                                       f.id AS {nameof(FollowQueryEntity.FollowingId)},
                                       f.first_name AS {nameof(FollowQueryEntity.FollowingFirstName)},
                                       f.last_name AS {nameof(FollowQueryEntity.FollowingLastName)},
                                       f.user_name AS {nameof(FollowQueryEntity.FollowingName)},
                                       f.email AS {nameof(FollowQueryEntity.FollowingEmail)},
                                       f.profile_image AS {nameof(FollowQueryEntity.FollowingProfileImage)},
                                       f.created_at AS {nameof(FollowQueryEntity.FollowingCreatedAt)},
                                       f.updated_at AS {nameof(FollowQueryEntity.FollowingUpdatedAt)},
                                   FROM follows pl
                                   INNER JOIN users u ON pl.{nameof(FollowQueryEntity.FollowerId)} = u.{nameof(UserQueryEntity.Id)}
                                   INNER JOIN users f ON pl.{nameof(FollowQueryEntity.FollowingId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pl.{nameof(FollowQueryEntity.FollowingId)} = {nameof(GetAllFollowsByFollowingQueryParameters.FollowingId)}
                                     AND pl.{nameof(FollowQueryEntity.FollowerName)} = @{nameof(GetAllFollowsByFollowingQueryParameters.FollowerName)}
                                   ORDER BY @{nameof(GetAllFollowsByFollowingQueryParameters.SortProperty)} @{nameof(GetAllFollowsByFollowingQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllFollowsByFollowingQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllFollowsByFollowingQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllByFollowingTotalCount = $@"SELECT COUNT(*)
                                              FROM follows pl
                                              INNER JOIN users u ON pl.{nameof(FollowQueryEntity.FollowerId)} = u.{nameof(UserQueryEntity.Id)}
                                              INNER JOIN users f ON pl.{nameof(FollowQueryEntity.FollowingId)} = u.{nameof(UserQueryEntity.Id)}
                                              WHERE pl.{nameof(FollowQueryEntity.FollowingId)} = @{nameof(GetAllFollowsByFollowingTotalCountQueryParameters.FollowingId)}
                                                AND pl.{nameof(FollowQueryEntity.FollowerName)} = @{nameof(GetAllFollowsByFollowingTotalCountQueryParameters.FollowerName)};";

    public const string GetById = $@"SELECT
                                       pl.created_at AS {nameof(FollowQueryEntity.CreatedAt)},
                                       pl.updated_at AS {nameof(FollowQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(FollowQueryEntity.FollowerId)},
                                       u.first_name AS {nameof(FollowQueryEntity.FollowerFirstName)},
                                       u.last_name AS {nameof(FollowQueryEntity.FollowerLastName)},
                                       u.user_name AS {nameof(FollowQueryEntity.FollowerName)},
                                       u.email AS {nameof(FollowQueryEntity.FollowerEmail)},
                                       u.profile_image AS {nameof(FollowQueryEntity.FollowerProfileImage)},
                                       u.created_at AS {nameof(FollowQueryEntity.FollowerCreatedAt)},
                                       u.updated_at AS {nameof(FollowQueryEntity.FollowerUpdatedAt)},
                                       f.id AS {nameof(FollowQueryEntity.FollowingId)},
                                       f.first_name AS {nameof(FollowQueryEntity.FollowingFirstName)},
                                       f.last_name AS {nameof(FollowQueryEntity.FollowingLastName)},
                                       f.user_name AS {nameof(FollowQueryEntity.FollowingName)},
                                       f.email AS {nameof(FollowQueryEntity.FollowingEmail)},
                                       f.profile_image AS {nameof(FollowQueryEntity.FollowingProfileImage)},
                                       f.created_at AS {nameof(FollowQueryEntity.FollowingCreatedAt)},
                                       f.updated_at AS {nameof(FollowQueryEntity.FollowingUpdatedAt)},
                                   FROM follows pl
                                   INNER JOIN users u ON pl.{nameof(FollowQueryEntity.FollowerId)} = u.{nameof(UserQueryEntity.Id)}
                                   INNER JOIN users f ON pl.{nameof(FollowQueryEntity.FollowingId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pl.{nameof(FollowQueryEntity.FollowerId)} = @{nameof(GetFollowByIdQueryParameters.FollowerId)}
                                     AND pl.{nameof(FollowQueryEntity.FollowingId)} = @{nameof(GetFollowByIdQueryParameters.FollowingId)};";
}
