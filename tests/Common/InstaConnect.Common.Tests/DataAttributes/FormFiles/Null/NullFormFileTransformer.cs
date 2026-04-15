using InstaConnect.Common.Tests.DataAttributes.FormFiles.Base;

using Microsoft.AspNetCore.Http;

namespace InstaConnect.Common.Tests.DataAttributes.FormFiles.Null;

internal class NullFormFileTransformer : IFormFileTransformer
{
    public IFormFile Transform(IFormFile? value)
    {
        return null!;
    }
}

