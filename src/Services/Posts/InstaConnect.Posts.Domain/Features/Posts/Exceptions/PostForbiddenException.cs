namespace InstaConnect.Common.Exceptions.Users;

public class PostForbiddenException : ForbiddenException
{
    private const string ErrorMessage = "Post access is forbidden";

    public PostForbiddenException() : base(ErrorMessage)
    {
    }

    public PostForbiddenException(Exception exception) : base(ErrorMessage, exception)
    {
    }
}
