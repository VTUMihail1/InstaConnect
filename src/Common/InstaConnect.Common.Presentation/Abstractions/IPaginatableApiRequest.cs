namespace InstaConnect.Common.Presentation.Abstractions;

public interface IPaginatableApiRequest
{
    public int Page { get; }

    public int PageSize { get; }
}
