using InstaConnect.Shared.Data.Abstract;

namespace InstaConnect.Messages.Read.Business.Queries.Messages.GetAllFilteredMessages;

public interface IEntityPropertyValidator
{
    public bool IsEntityPropertyValid<T>(string propertyName) where T : IBaseEntity;
}
