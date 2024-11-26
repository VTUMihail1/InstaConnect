namespace InstaConnect.Shared.Application.Abstractions;

public interface IJsonConverter
{
    T? Deserialize<T>(string value);
    string Serialize(object obj);
}
