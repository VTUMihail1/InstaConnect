using InstaConnect.Chats.Infrastructure.Features.Chats.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.Chats.Infrastructure.Features.Chats.Utilities;

public static class ChatQuerySql
{
    public const string GetAllByParticipant = $@"
                                   SELECT *
                                   FROM (
                                       SELECT 
                                           pl.created_at AS {nameof(ChatQueryEntity.CreatedAt)},
                                           pl.updated_at AS {nameof(ChatQueryEntity.UpdatedAt)},
                                   
                                           u.id          AS {nameof(ChatQueryEntity.ParticipantOneId)},
                                           u.first_name  AS {nameof(ChatQueryEntity.ParticipantOneFirstName)},
                                           u.last_name   AS {nameof(ChatQueryEntity.ParticipantOneLastName)},
                                           u.user_name   AS {nameof(ChatQueryEntity.ParticipantOneName)},
                                           u.email       AS {nameof(ChatQueryEntity.ParticipantOneEmail)},
                                           u.profile_image AS {nameof(ChatQueryEntity.ParticipantOneProfileImage)},
                                           u.created_at  AS {nameof(ChatQueryEntity.ParticipantOneCreatedAt)},
                                           u.updated_at  AS {nameof(ChatQueryEntity.ParticipantOneUpdatedAt)},
                                   
                                           f.id          AS {nameof(ChatQueryEntity.ParticipantTwoId)},
                                           f.first_name  AS {nameof(ChatQueryEntity.ParticipantTwoFirstName)},
                                           f.last_name   AS {nameof(ChatQueryEntity.ParticipantTwoLastName)},
                                           f.user_name   AS {nameof(ChatQueryEntity.ParticipantTwoName)},
                                           f.email       AS {nameof(ChatQueryEntity.ParticipantTwoEmail)},
                                           f.profile_image AS {nameof(ChatQueryEntity.ParticipantTwoProfileImage)},
                                           f.created_at  AS {nameof(ChatQueryEntity.ParticipantTwoCreatedAt)},
                                           f.updated_at  AS {nameof(ChatQueryEntity.ParticipantTwoUpdatedAt)}
                                   
                                       FROM chats pl
                                       INNER JOIN users u ON pl.{nameof(ChatQueryEntity.ParticipantOneId)} = u.{nameof(UserQueryEntity.Id)}
                                       INNER JOIN users f ON pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = f.{nameof(UserQueryEntity.Id)}
                                       WHERE pl.{nameof(ChatQueryEntity.ParticipantOneId)} = @{nameof(GetAllChatsByParticipantQueryParameters.ParticipantId)}
                                         AND f.{nameof(UserQueryEntity.Name)} = @{nameof(GetAllChatsByParticipantQueryParameters.ParticipantName)}
                                   
                                       UNION ALL
                                   
                                       SELECT 
                                           pl.created_at AS {nameof(ChatQueryEntity.CreatedAt)},
                                           pl.updated_at AS {nameof(ChatQueryEntity.UpdatedAt)},
                                   
                                           f.id          AS {nameof(ChatQueryEntity.ParticipantOneId)},
                                           f.first_name  AS {nameof(ChatQueryEntity.ParticipantOneFirstName)},
                                           f.last_name   AS {nameof(ChatQueryEntity.ParticipantOneLastName)},
                                           f.user_name   AS {nameof(ChatQueryEntity.ParticipantOneName)},
                                           f.email       AS {nameof(ChatQueryEntity.ParticipantOneEmail)},
                                           f.profile_image AS {nameof(ChatQueryEntity.ParticipantOneProfileImage)},
                                           f.created_at  AS {nameof(ChatQueryEntity.ParticipantOneCreatedAt)},
                                           f.updated_at  AS {nameof(ChatQueryEntity.ParticipantOneUpdatedAt)},
                                   
                                           u.id          AS {nameof(ChatQueryEntity.ParticipantTwoId)},
                                           u.first_name  AS {nameof(ChatQueryEntity.ParticipantTwoFirstName)},
                                           u.last_name   AS {nameof(ChatQueryEntity.ParticipantTwoLastName)},
                                           u.user_name   AS {nameof(ChatQueryEntity.ParticipantTwoName)},
                                           u.email       AS {nameof(ChatQueryEntity.ParticipantTwoEmail)},
                                           u.profile_image AS {nameof(ChatQueryEntity.ParticipantTwoProfileImage)},
                                           u.created_at  AS {nameof(ChatQueryEntity.ParticipantTwoCreatedAt)},
                                           u.updated_at  AS {nameof(ChatQueryEntity.ParticipantTwoUpdatedAt)}
                                   
                                       FROM chats pl
                                       INNER JOIN users u ON pl.{nameof(ChatQueryEntity.ParticipantOneId)} = u.{nameof(UserQueryEntity.Id)}
                                       INNER JOIN users f ON pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = f.{nameof(UserQueryEntity.Id)}
                                       WHERE pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = @{nameof(GetAllChatsByParticipantQueryParameters.ParticipantId)}
                                         AND u.{nameof(UserQueryEntity.Name)} = @{nameof(GetAllChatsByParticipantQueryParameters.ParticipantName)}
                                   ) normalized_chats
                                   
                                   ORDER BY 
                                       {nameof(GetAllChatsByParticipantQueryParameters.SortProperty)} 
                                       {nameof(GetAllChatsByParticipantQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllChatsByParticipantQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllChatsByParticipantQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllByParticipantTotalCount = $@"
                                              SELECT COUNT(*)
                                              FROM (
                                                  SELECT pl.id
                                                  FROM chats pl
                                                  INNER JOIN users u ON pl.{nameof(ChatQueryEntity.ParticipantOneId)} = u.{nameof(UserQueryEntity.Id)}
                                                  INNER JOIN users f ON pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = f.{nameof(UserQueryEntity.Id)}
                                                  WHERE pl.{nameof(ChatQueryEntity.ParticipantOneId)} = @{nameof(GetAllChatsByParticipantTotalCountQueryParameters.ParticipantId)}
                                                    AND f.{nameof(UserQueryEntity.Name)} = @{nameof(GetAllChatsByParticipantTotalCountQueryParameters.ParticipantName)}
                                              
                                                  UNION ALL
                                              
                                                  SELECT pl.id
                                                  FROM chats pl
                                                  INNER JOIN users u ON pl.{nameof(ChatQueryEntity.ParticipantOneId)} = u.{nameof(UserQueryEntity.Id)}
                                                  INNER JOIN users f ON pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = f.{nameof(UserQueryEntity.Id)}
                                                  WHERE pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = @{nameof(GetAllChatsByParticipantTotalCountQueryParameters.ParticipantId)}
                                                    AND u.{nameof(UserQueryEntity.Name)} = @{nameof(GetAllChatsByParticipantTotalCountQueryParameters.ParticipantName)}
                                              ) normalized_chats;";

    public const string GetById = $@"
                                     SELECT *
                                     FROM (
                                         SELECT 
                                             pl.created_at AS {nameof(ChatQueryEntity.CreatedAt)},
                                             pl.updated_at AS {nameof(ChatQueryEntity.UpdatedAt)},
                                     
                                             u.id           AS {nameof(ChatQueryEntity.ParticipantOneId)},
                                             u.first_name   AS {nameof(ChatQueryEntity.ParticipantOneFirstName)},
                                             u.last_name    AS {nameof(ChatQueryEntity.ParticipantOneLastName)},
                                             u.user_name    AS {nameof(ChatQueryEntity.ParticipantOneName)},
                                             u.email        AS {nameof(ChatQueryEntity.ParticipantOneEmail)},
                                             u.profile_image AS {nameof(ChatQueryEntity.ParticipantOneProfileImage)},
                                             u.created_at   AS {nameof(ChatQueryEntity.ParticipantOneCreatedAt)},
                                             u.updated_at   AS {nameof(ChatQueryEntity.ParticipantOneUpdatedAt)},
                                     
                                             f.id           AS {nameof(ChatQueryEntity.ParticipantTwoId)},
                                             f.first_name   AS {nameof(ChatQueryEntity.ParticipantTwoFirstName)},
                                             f.last_name    AS {nameof(ChatQueryEntity.ParticipantTwoLastName)},
                                             f.user_name    AS {nameof(ChatQueryEntity.ParticipantTwoName)},
                                             f.email        AS {nameof(ChatQueryEntity.ParticipantTwoEmail)},
                                             f.profile_image AS {nameof(ChatQueryEntity.ParticipantTwoProfileImage)},
                                             f.created_at   AS {nameof(ChatQueryEntity.ParticipantTwoCreatedAt)},
                                             f.updated_at   AS {nameof(ChatQueryEntity.ParticipantTwoUpdatedAt)}
                                     
                                         FROM chats pl
                                         INNER JOIN users u ON pl.{nameof(ChatQueryEntity.ParticipantOneId)} = u.{nameof(UserQueryEntity.Id)}
                                         INNER JOIN users f ON pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = f.{nameof(UserQueryEntity.Id)}
                                         WHERE pl.{nameof(ChatQueryEntity.ParticipantOneId)} = @{nameof(GetChatByIdQueryParameters.ParticipantOneId)}
                                           AND pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = @{nameof(GetChatByIdQueryParameters.ParticipantTwoId)}
                                     
                                         UNION ALL
                                     
                                         SELECT 
                                             pl.created_at AS {nameof(ChatQueryEntity.CreatedAt)},
                                             pl.updated_at AS {nameof(ChatQueryEntity.UpdatedAt)},
                                     
                                             f.id           AS {nameof(ChatQueryEntity.ParticipantOneId)},
                                             f.first_name   AS {nameof(ChatQueryEntity.ParticipantOneFirstName)},
                                             f.last_name    AS {nameof(ChatQueryEntity.ParticipantOneLastName)},
                                             f.user_name    AS {nameof(ChatQueryEntity.ParticipantOneName)},
                                             f.email        AS {nameof(ChatQueryEntity.ParticipantOneEmail)},
                                             f.profile_image AS {nameof(ChatQueryEntity.ParticipantOneProfileImage)},
                                             f.created_at   AS {nameof(ChatQueryEntity.ParticipantOneCreatedAt)},
                                             f.updated_at   AS {nameof(ChatQueryEntity.ParticipantOneUpdatedAt)},
                                     
                                             u.id           AS {nameof(ChatQueryEntity.ParticipantTwoId)},
                                             u.first_name   AS {nameof(ChatQueryEntity.ParticipantTwoFirstName)},
                                             u.last_name    AS {nameof(ChatQueryEntity.ParticipantTwoLastName)},
                                             u.user_name    AS {nameof(ChatQueryEntity.ParticipantTwoName)},
                                             u.email        AS {nameof(ChatQueryEntity.ParticipantTwoEmail)},
                                             u.profile_image AS {nameof(ChatQueryEntity.ParticipantTwoProfileImage)},
                                             u.created_at   AS {nameof(ChatQueryEntity.ParticipantTwoCreatedAt)},
                                             u.updated_at   AS {nameof(ChatQueryEntity.ParticipantTwoUpdatedAt)}
                                     
                                         FROM chats pl
                                         INNER JOIN users u ON pl.{nameof(ChatQueryEntity.ParticipantOneId)} = u.{nameof(UserQueryEntity.Id)}
                                         INNER JOIN users f ON pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = f.{nameof(UserQueryEntity.Id)}
                                         WHERE pl.{nameof(ChatQueryEntity.ParticipantTwoId)} = @{nameof(GetChatByIdQueryParameters.ParticipantOneId)}
                                           AND pl.{nameof(ChatQueryEntity.ParticipantOneId)} = @{nameof(GetChatByIdQueryParameters.ParticipantTwoId)}
                                     ) normalized_chat;";
}
