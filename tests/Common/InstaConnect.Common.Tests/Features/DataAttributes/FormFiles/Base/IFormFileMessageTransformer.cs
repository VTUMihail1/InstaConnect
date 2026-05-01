using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.Features.DataAttributes.FormFiles.Base;

public interface IFormFileMessageTransformer : IMessageTransformer<IFormFile>;
