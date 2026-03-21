using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.DataAttributes.FormFiles.Base;

public interface IFormFileMessageTransformer : IMessageTransformer<IFormFile>;
