namespace InstaConnect.Common.Application.Features.Messaging.Abstractions;

public interface IPaginatableQueryRequest
{
    public int Page { get; }

    public int PageSize { get; }
}
