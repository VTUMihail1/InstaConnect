namespace InstaConnect.Chats.Presentation.Features.Chats.Models.Requests;

public record GetAllChatsByParticipantApiRequest(
    [FromQuery] ChatByParticipantFilterApiRequest Filter,
    [FromQuery] ChatByParticipantSortingApiRequest Sorting,
    [FromQuery] ChatPaginationApiRequest Pagination);
