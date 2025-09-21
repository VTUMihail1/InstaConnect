using InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.PostLikes.Infrastructure.Features.PostLikes.Utilities;

public static class PostLikeQuerySql
{
    public const string GetAll = $@"SELECT 
                                       pl.id AS {nameof(PostLikeQueryEntity.Id)},
                                       pl.user_id AS {nameof(PostLikeQueryEntity.UserId)},
                                       pl.created_at AS {nameof(PostLikeQueryEntity.CreatedAt)},
                                       pl.updated_at AS {nameof(PostLikeQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostLikeQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostLikeQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostLikeQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostLikeQueryEntity.UserName)},
                                       u.email AS {nameof(PostLikeQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostLikeQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostLikeQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostLikeQueryEntity.UserUpdatedAt)},
                                   FROM post_likes pl
                                   INNER JOIN users u ON pl.{nameof(PostLikeQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pl.{nameof(PostLikeQueryEntity.Id)} = {nameof(GetAllPostLikesQueryParameters.Id)}
                                     AND u.{nameof(PostLikeQueryEntity.UserName)} LIKE @{nameof(GetAllPostLikesQueryParameters.UserName)}
                                   ORDER BY @{nameof(GetAllPostLikesQueryParameters.SortProperty)} @{nameof(GetAllPostLikesQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllPostLikesQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllPostLikesQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllTotalCount = $@"SELECT COUNT(*)
                                              FROM post_likes pl
                                              INNER JOIN users u ON pl.{nameof(PostLikeQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                              WHERE pl.{nameof(PostLikeQueryEntity.Id)} = @{nameof(GetAllPostLikesQueryParameters.Id)}
                                                AND u.{nameof(PostLikeQueryEntity.UserName)} LIKE @{nameof(GetAllPostLikesQueryParameters.UserName)};";

    public const string GetById = $@"SELECT
                                       pl.id AS {nameof(PostLikeQueryEntity.Id)},
                                       pl.user_id AS {nameof(PostLikeQueryEntity.UserId)},
                                       pl.created_at AS {nameof(PostLikeQueryEntity.CreatedAt)},
                                       pl.updated_at AS {nameof(PostLikeQueryEntity.UpdatedAt)},
                                       u.id AS {nameof(PostLikeQueryEntity.UserId)},
                                       u.first_name AS {nameof(PostLikeQueryEntity.UserFirstName)},
                                       u.last_name AS {nameof(PostLikeQueryEntity.UserLastName)},
                                       u.user_name AS {nameof(PostLikeQueryEntity.UserName)},
                                       u.email AS {nameof(PostLikeQueryEntity.UserEmail)},
                                       u.profile_image AS {nameof(PostLikeQueryEntity.UserProfileImage)},
                                       u.created_at AS {nameof(PostLikeQueryEntity.UserCreatedAt)},
                                       u.updated_at AS {nameof(PostLikeQueryEntity.UserUpdatedAt)},
                                   FROM post_likes pl
                                   INNER JOIN users u ON pl.{nameof(PostLikeQueryEntity.UserId)} = u.{nameof(UserQueryEntity.Id)}
                                   WHERE pl.{nameof(PostLikeQueryEntity.Id)} = @{nameof(GetPostLikeByIdQueryParameters.Id)}
                                     AND pl.{nameof(PostLikeQueryEntity.UserId)} = @{nameof(GetPostLikeByIdQueryParameters.UserId)};";
}
