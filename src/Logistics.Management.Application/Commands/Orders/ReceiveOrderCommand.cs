namespace Logistics.Management.Application.Commands.Orders
{
    public class ReceiveOrderCommand : BaseOrderCommand<bool>
    {
        public ReceiveOrderCommand(Guid id) => Id = id;
    }
}