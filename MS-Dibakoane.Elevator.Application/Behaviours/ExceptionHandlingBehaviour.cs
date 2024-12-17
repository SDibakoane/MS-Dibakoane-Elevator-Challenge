using MediatR;
using Microsoft.Extensions.Logging;

namespace MS_Dibakoane.Elevator.Application.Behaviours;

public sealed class ExceptionHandlingBehaviour<TRequest, TResponse>
    (ILogger<ExceptionHandlingBehaviour<TRequest, TResponse>> logger) 
    : IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            return await next();
        }
        catch (Exception exception)
        {
            logger.LogError(exception, "An unhandled exception for {RequestName} occurred", typeof(TRequest).Name);
            throw;
        }
    }
}