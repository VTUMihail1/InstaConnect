namespace InstaConnect.Common.Application.Abstractions;

public interface IPaginatableQueryRequest
{
    public int Page { get; }

    public int PageSize { get; }
}
