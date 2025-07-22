namespace InstaConnect.Messages.Application.Features.Messages.Queries.GetById;

public record GetMessageByIdQuery(string Id, string CurrentUserId) : IQueryRequest<MessageQueryViewModel>;
