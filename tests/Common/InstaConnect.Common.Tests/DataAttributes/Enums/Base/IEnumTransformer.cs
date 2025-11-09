namespace InstaConnect.Common.Tests.DataAttributes.Enums.Base;
public interface IEnumTransformer<TEnum>
        where TEnum : Enum
{
    public TEnum Transform(TEnum value);
}
