namespace InstaConnect.Shared.Business.Abstractions;

public interface IEnumValidator
{
    public bool IsEnumValid<T>(string enumValueName) where T : Enum;
}
