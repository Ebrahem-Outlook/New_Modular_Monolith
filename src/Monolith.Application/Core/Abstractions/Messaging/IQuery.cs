using MediatR;

namespace Monolith.Application.Core.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse> 
    where TResponse : class
{

}
