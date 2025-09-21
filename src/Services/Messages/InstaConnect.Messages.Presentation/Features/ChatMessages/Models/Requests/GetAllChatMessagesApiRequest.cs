namespace InstaConnect.ChatMessages.Presentation.Features.ChatMessages.Models.Requests;

public record GetAllChatMessagesApiRequest(
    [FromQuery] ChatMessageFilterApiRequest Filter,
    [FromQuery] ChatMessageSortingApiRequest Sorting,
    [FromQuery] ChatMessagePaginationApiRequest Pagination);
