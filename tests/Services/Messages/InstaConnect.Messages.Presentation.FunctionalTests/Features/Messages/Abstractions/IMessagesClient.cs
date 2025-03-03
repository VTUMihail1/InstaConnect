﻿namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Abstractions;
public interface IMessagesClient
{
    Task<MessageCommandResponse> AddAsync(AddMessageRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeAsync(AddMessageRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> AddStatusCodeUnauthorizedAsync(AddMessageRequest request, CancellationToken cancellationToken);
    Task DeleteAsync(DeleteMessageRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeAsync(DeleteMessageRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> DeleteStatusCodeUnauthorizedAsync(DeleteMessageRequest request, CancellationToken cancellationToken);
    Task<MessagePaginationQueryResponse> GetAllAsync(GetAllMessagesRequest request, CancellationToken cancellationToken);
    Task<MessagePaginationQueryResponse> GetAllAsync(string currentUserId, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeAsync(GetAllMessagesRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetAllStatusCodeUnauthorizedAsync(GetAllMessagesRequest request, CancellationToken cancellationToken);
    Task<MessageQueryResponse> GetByIdAsync(GetMessageByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeAsync(GetMessageByIdRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> GetByIdStatusCodeUnathorizedAsync(GetMessageByIdRequest request, CancellationToken cancellationToken);
    Task<MessageCommandResponse> UpdateAsync(UpdateMessageRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeAsync(UpdateMessageRequest request, CancellationToken cancellationToken);
    Task<HttpStatusCode> UpdateStatusCodeUnauthorizedAsync(UpdateMessageRequest request, CancellationToken cancellationToken);
}