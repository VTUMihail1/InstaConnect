using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

public class EntityPropertyValidator : IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity
    {
        var isValidProperty = typeof(T).GetProperties().Any(e => e.Name == propertyName);

        return isValidProperty;
    }
}
