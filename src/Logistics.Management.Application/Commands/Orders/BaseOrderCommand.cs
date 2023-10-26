using MediatR;

namespace Logistics.Management.Application.Commands.Orders
{
    public abstract class BaseOrderCommand<TResponse> : IRequest<TResponse>
    {
        public Guid Id { get; protected set; }
        public string Description { get; protected set; } = string.Empty;
        public List<(Guid ItemId, int Quantity)> Items { get; protected set; } = new List<(Guid ItemId, int Quantity)>();
    }
}