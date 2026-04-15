namespace InstaConnect.Common.Tests.DataAttributes.Enums.Base;

public interface IEnumMessageTransformer<TEnum> : IMessageTransformer<TEnum>
    where TEnum : Enum;
