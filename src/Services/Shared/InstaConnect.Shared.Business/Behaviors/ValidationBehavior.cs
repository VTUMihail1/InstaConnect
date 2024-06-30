using AutoMapper;
using FluentValidation;
using InstaConnect.Shared.Business.Abstractions;
using InstaConnect.Shared.Business.Exceptions.Base;
using MediatR;

namespace InstaConnect.Shared.Business.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand<TResponse>, IQuery<TResponse>
{
    private readonly IMapper _mapper;
    private readonly ICollection<IValidator<TRequest>> _validators;

    public ValidationBehavior(
        IMapper mapper,
        ICollection<IValidator<TRequest>> validators)
    {
        _mapper = mapper;
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var validationContext = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(validationContext)));

        var validationFailures = validationResults
            .Where(vr => !vr.IsValid)
            .SelectMany(vr => vr.Errors)
            .Select(vr => vr.ErrorMessage);

        if (validationFailures.Any())
        {
            var errorMessage = string.Join(",\n", validationFailures);

            throw new BadRequestException(errorMessage);
        }

        return await next();
    }
}
