using InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Models;
using InstaConnect.Posts.Infrastructure.Features.Posts.Models;

namespace InstaConnect.ChatMessages.Infrastructure.Features.ChatMessages.Utilities;

public static class ChatMessageQuerySql
{
    public const string GetAll = $@"
                                   SELECT *
                                   FROM (
                                       SELECT
                                           pl.participant_one_id AS {nameof(ChatMessageQueryEntity.ParticipantOneId)},
                                           pl.participant_two_id AS {nameof(ChatMessageQueryEntity.ParticipantTwoId)},
                                           pl.message_id AS {nameof(ChatMessageQueryEntity.MessageId)},
                                           pl.content AS {nameof(ChatMessageQueryEntity.Content)},
                                           pl.created_at AS {nameof(ChatMessageQueryEntity.CreatedAt)},
                                           pl.updated_at AS {nameof(ChatMessageQueryEntity.UpdatedAt)},
                                   
                                           u.id            AS {nameof(ChatMessageQueryEntity.SenderId)},
                                           u.first_name    AS {nameof(ChatMessageQueryEntity.SenderFirstName)},
                                           u.last_name     AS {nameof(ChatMessageQueryEntity.SenderLastName)},
                                           u.user_name     AS {nameof(ChatMessageQueryEntity.SenderName)},
                                           u.email         AS {nameof(ChatMessageQueryEntity.SenderEmail)},
                                           u.profile_image AS {nameof(ChatMessageQueryEntity.SenderProfileImage)},
                                           u.created_at    AS {nameof(ChatMessageQueryEntity.SenderCreatedAt)},
                                           u.updated_at    AS {nameof(ChatMessageQueryEntity.SenderUpdatedAt)}
                                   
                                       FROM chat_messages pl
                                       INNER JOIN users u ON pl.{nameof(ChatMessageQueryEntity.SenderId)} = u.{nameof(UserQueryEntity.Id)}
                                       WHERE pl.{nameof(ChatMessageQueryEntity.ParticipantOneId)} = @{nameof(GetAllChatMessagesQueryParameters.ParticipantOneId)}
                                         AND pl.{nameof(ChatMessageQueryEntity.ParticipantTwoId)} = @{nameof(GetAllChatMessagesQueryParameters.ParticipantTwoId)}
                                   
                                       UNION ALL
                                   
                                       SELECT
                                           pl.participant_one_id AS {nameof(ChatMessageQueryEntity.ParticipantOneId)},
                                           pl.participant_two_id AS {nameof(ChatMessageQueryEntity.ParticipantTwoId)},
                                           pl.message_id AS {nameof(ChatMessageQueryEntity.MessageId)},
                                           pl.content AS {nameof(ChatMessageQueryEntity.Content)},
                                           pl.created_at AS {nameof(ChatMessageQueryEntity.CreatedAt)},
                                           pl.updated_at AS {nameof(ChatMessageQueryEntity.UpdatedAt)},
                                   
                                           u.id            AS {nameof(ChatMessageQueryEntity.SenderId)},
                                           u.first_name    AS {nameof(ChatMessageQueryEntity.SenderFirstName)},
                                           u.last_name     AS {nameof(ChatMessageQueryEntity.SenderLastName)},
                                           u.user_name     AS {nameof(ChatMessageQueryEntity.SenderName)},
                                           u.email         AS {nameof(ChatMessageQueryEntity.SenderEmail)},
                                           u.profile_image AS {nameof(ChatMessageQueryEntity.SenderProfileImage)},
                                           u.created_at    AS {nameof(ChatMessageQueryEntity.SenderCreatedAt)},
                                           u.updated_at    AS {nameof(ChatMessageQueryEntity.SenderUpdatedAt)}
                                   
                                       FROM chat_messages pl
                                       INNER JOIN users u ON pl.{nameof(ChatMessageQueryEntity.SenderId)} = u.{nameof(UserQueryEntity.Id)}
                                       WHERE pl.{nameof(ChatMessageQueryEntity.ParticipantOneId)} = @{nameof(GetAllChatMessagesQueryParameters.ParticipantTwoId)}
                                         AND pl.{nameof(ChatMessageQueryEntity.ParticipantTwoId)} = @{nameof(GetAllChatMessagesQueryParameters.ParticipantOneId)}
                                   ) normalized_chat_messages
                                   
                                   ORDER BY 
                                       {nameof(GetAllChatMessagesQueryParameters.SortProperty)} 
                                       {nameof(GetAllChatMessagesQueryParameters.SortOrder)}
                                   OFFSET @{nameof(GetAllChatMessagesQueryParameters.Offset)} ROWS
                                   FETCH NEXT @{nameof(GetAllChatMessagesQueryParameters.Limit)} ROWS ONLY;";

    public const string GetAllTotalCount = $@"
                                             SELECT COUNT(*)
                                             FROM (
                                                 SELECT pl.message_id
                                                 FROM chat_messages pl
                                                 INNER JOIN users u ON pl.{nameof(ChatMessageQueryEntity.SenderId)} = u.{nameof(UserQueryEntity.Id)}
                                                 WHERE pl.{nameof(ChatMessageQueryEntity.ParticipantOneId)} = @{nameof(GetAllChatMessagesTotalCountQueryParameters.ParticipantOneId)}
                                                   AND pl.{nameof(ChatMessageQueryEntity.ParticipantTwoId)} = @{nameof(GetAllChatMessagesTotalCountQueryParameters.ParticipantTwoId)}
                                             
                                                 UNION ALL
                                             
                                                 SELECT pl.message_id
                                                 FROM chat_messages pl
                                                 INNER JOIN users u ON pl.{nameof(ChatMessageQueryEntity.SenderId)} = u.{nameof(UserQueryEntity.Id)}
                                                 WHERE pl.{nameof(ChatMessageQueryEntity.ParticipantOneId)} = @{nameof(GetAllChatMessagesTotalCountQueryParameters.ParticipantTwoId)}
                                                   AND pl.{nameof(ChatMessageQueryEntity.ParticipantTwoId)} = @{nameof(GetAllChatMessagesTotalCountQueryParameters.ParticipantOneId)}
                                             ) normalized_chat_messages;";

    public const string GetById = $@"
                                     SELECT *
                                     FROM (
                                         SELECT
                                             pl.participant_one_id AS {nameof(ChatMessageQueryEntity.ParticipantOneId)},
                                             pl.participant_two_id AS {nameof(ChatMessageQueryEntity.ParticipantTwoId)},
                                             pl.message_id         AS {nameof(ChatMessageQueryEntity.MessageId)},
                                             pl.content            AS {nameof(ChatMessageQueryEntity.Content)},
                                             pl.created_at         AS {nameof(ChatMessageQueryEntity.CreatedAt)},
                                             pl.updated_at         AS {nameof(ChatMessageQueryEntity.UpdatedAt)},
                                     
                                             u.id                  AS {nameof(ChatMessageQueryEntity.SenderId)},
                                             u.first_name          AS {nameof(ChatMessageQueryEntity.SenderFirstName)},
                                             u.last_name           AS {nameof(ChatMessageQueryEntity.SenderLastName)},
                                             u.user_name           AS {nameof(ChatMessageQueryEntity.SenderName)},
                                             u.email               AS {nameof(ChatMessageQueryEntity.SenderEmail)},
                                             u.profile_image       AS {nameof(ChatMessageQueryEntity.SenderProfileImage)},
                                             u.created_at          AS {nameof(ChatMessageQueryEntity.SenderCreatedAt)},
                                             u.updated_at          AS {nameof(ChatMessageQueryEntity.SenderUpdatedAt)}
                                     
                                         FROM chat_messages pl
                                         INNER JOIN users u ON pl.{nameof(ChatMessageQueryEntity.SenderId)} = u.{nameof(UserQueryEntity.Id)}
                                         WHERE pl.{nameof(ChatMessageQueryEntity.ParticipantOneId)} = @{nameof(GetChatMessageByIdQueryParameters.ParticipantOneId)}
                                           AND pl.{nameof(ChatMessageQueryEntity.ParticipantTwoId)} = @{nameof(GetChatMessageByIdQueryParameters.ParticipantTwoId)}
                                           AND pl.{nameof(ChatMessageQueryEntity.MessageId)} = @{nameof(GetChatMessageByIdQueryParameters.MessageId)}
                                     
                                         UNION ALL
                                     
                                         SELECT
                                             pl.participant_one_id AS {nameof(ChatMessageQueryEntity.ParticipantOneId)},
                                             pl.participant_two_id AS {nameof(ChatMessageQueryEntity.ParticipantTwoId)},
                                             pl.message_id         AS {nameof(ChatMessageQueryEntity.MessageId)},
                                             pl.content            AS {nameof(ChatMessageQueryEntity.Content)},
                                             pl.created_at         AS {nameof(ChatMessageQueryEntity.CreatedAt)},
                                             pl.updated_at         AS {nameof(ChatMessageQueryEntity.UpdatedAt)},
                                     
                                             u.id                  AS {nameof(ChatMessageQueryEntity.SenderId)},
                                             u.first_name          AS {nameof(ChatMessageQueryEntity.SenderFirstName)},
                                             u.last_name           AS {nameof(ChatMessageQueryEntity.SenderLastName)},
                                             u.user_name           AS {nameof(ChatMessageQueryEntity.SenderName)},
                                             u.email               AS {nameof(ChatMessageQueryEntity.SenderEmail)},
                                             u.profile_image       AS {nameof(ChatMessageQueryEntity.SenderProfileImage)},
                                             u.created_at          AS {nameof(ChatMessageQueryEntity.SenderCreatedAt)},
                                             u.updated_at          AS {nameof(ChatMessageQueryEntity.SenderUpdatedAt)}
                                     
                                         FROM chat_messages pl
                                         INNER JOIN users u ON pl.{nameof(ChatMessageQueryEntity.SenderId)} = u.{nameof(UserQueryEntity.Id)}
                                         WHERE pl.{nameof(ChatMessageQueryEntity.ParticipantOneId)} = @{nameof(GetChatMessageByIdQueryParameters.ParticipantTwoId)}
                                           AND pl.{nameof(ChatMessageQueryEntity.ParticipantTwoId)} = @{nameof(GetChatMessageByIdQueryParameters.ParticipantOneId)}
                                           AND pl.{nameof(ChatMessageQueryEntity.MessageId)} = @{nameof(GetChatMessageByIdQueryParameters.MessageId)}
                                     ) normalized_chat_message;";
}
