namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

public interface IEnumValidator
{
    public bool IsEnumValid<T>(string enumValueName) where T : Enum;
}
