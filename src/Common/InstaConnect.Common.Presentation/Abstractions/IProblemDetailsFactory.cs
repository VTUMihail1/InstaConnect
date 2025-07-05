using Microsoft.AspNetCore.Mvc;

namespace InstaConnect.Common.Presentation.Abstractions;
public interface IProblemDetailsFactory
{
    ProblemDetails Create(Exception exception);
}