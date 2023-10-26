namespace Logistics.Management.Application.Commands.Orders
{
    public class RequestOrderCommand : BaseOrderCommand<bool>
    {
        public RequestOrderCommand(Guid id, string description, List<(Guid ItemId, int Quantity)> items)
        {
            Id = id;
            Description = description;
            Items = items;
        }
    }
}