namespace InstaConnect.Common.Domain.Features.Messaging.Abstractions;

public interface IPaginationQuery
{
    int Page { get; }

    int PageSize { get; }
}
