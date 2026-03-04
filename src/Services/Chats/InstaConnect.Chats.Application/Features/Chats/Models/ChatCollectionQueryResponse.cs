using InstaConnect.Chats.Domain.Features.Users.Models.Responses;

namespace InstaConnect.Chats.Application.Features.Chats.Models;

public record ChatCollectionQueryResponse(
    UserQueryResponse? ParticipantOne,
    UserQueryResponse? ParticipantTwo,
    ICollection<ChatQueryResponse> Chats,
    int Page,
    int PageSize,
    long TotalCount,
    bool HasNextPage,
    bool HasPreviousPage) : ICollectionQueryResponse;
