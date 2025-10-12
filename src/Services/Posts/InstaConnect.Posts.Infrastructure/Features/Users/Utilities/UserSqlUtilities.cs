using InstaConnect.PostComments.Domain.Features.PostComments.Models.Entities;
using InstaConnect.PostLikes.Domain.Features.PostLikes.Models.Entities;

namespace InstaConnect.Common.Infrastructure.SortOrders;

internal static class UserSqlUtilities
{
    public const string Select = $@"u.id AS {UserSqlProperties.Id},
                                    u.first_name AS {UserSqlProperties.FirstName},
                                    u.last_name AS {UserSqlProperties.LastName},
                                    u.user_name AS {UserSqlProperties.Name},
                                    u.email AS {UserSqlProperties.Email},
                                    u.profile_image AS {UserSqlProperties.ProfileImage},
                                    u.created_at AS {UserSqlProperties.CreatedAt},
                                    u.updated_at AS {UserSqlProperties.UpdatedAt},";

    public const string From = $@"users u";
}
