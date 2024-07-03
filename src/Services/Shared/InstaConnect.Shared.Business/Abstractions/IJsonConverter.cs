namespace InstaConnect.Shared.Business.Abstractions;

public interface IJsonConverter
{
    T? Deserialize<T>(string value);
    string Serialize(object obj);
}
