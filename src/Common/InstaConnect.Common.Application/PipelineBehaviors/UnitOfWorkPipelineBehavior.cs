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
        var response = await next();

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return response;
    }
}
