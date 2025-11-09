namespace InstaConnect.Messages.Presentation.FunctionalTests.Features.Messages.Utilities;
public abstract class MessageTestRoutes
{
    public const string Default = "api/v1/message";

    public const string GetAll = "api/v1/message?&receiverId={0}&receiverName={1}&sortOrder={2}&sortPropertyName={3}&page={4}&pageSize={5}";

    public const string Id = "api/v1/message/{0}";
}
