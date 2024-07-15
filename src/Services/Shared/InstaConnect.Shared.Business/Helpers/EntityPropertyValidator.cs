using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

internal class EntityPropertyValidator : IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity
    {
        var entityProperty = typeof(T).GetProperty(propertyName);

        return entityProperty != null;
    }
}
