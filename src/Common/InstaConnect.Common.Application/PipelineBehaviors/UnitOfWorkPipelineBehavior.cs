using MediatR;

namespace InstaConnect.Common.Application.PipelineBehaviors;

internal sealed class UnitOfWorkPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : ICommand
{
    private readonly IUnitOfWork _unitOfWork;

    public UnitOfWorkPipelineBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        await _unitOfWork.BeginAsync(cancellationToken);

        try
        {
            var response = await next();
            await _unitOfWork.CommitAsync(cancellationToken);

            return response;
        }
        catch
        {
            await _unitOfWork.AbortAsync(cancellationToken);

            throw;
        }
    }
}
