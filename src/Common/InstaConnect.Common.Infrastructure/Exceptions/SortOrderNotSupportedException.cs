using InstaConnect.Common.Exceptions.Base;

namespace InstaConnect.Common.Infrastructure.Exceptions;
public class SortOrderNotSupportedException : BadRequestException
{
    private const string ErrorMessage = "Sort order is not supported";

    public SortOrderNotSupportedException() : base(ErrorMessage)
    {
    }

    public SortOrderNotSupportedException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
