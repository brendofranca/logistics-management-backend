using Logistics.Management.Application.Responses;

namespace Logistics.Management.Application.Commands.Orders
{
    public class CollectOrderCommand : BaseOrderCommand<CollectOrderResponse?>
    {
        public Guid AvgId { get; set; }

        public CollectOrderCommand(Guid id, Guid avgId)
        {
            Id = id;
            AvgId = avgId;
        }
    }
}