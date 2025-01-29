namespace Logistics.Management.Application.Commands.Orders
{
    public class SendOrderCommand : BaseOrderCommand<bool>
    {
        public SendOrderCommand(Guid id) => Id = id;
    }
}