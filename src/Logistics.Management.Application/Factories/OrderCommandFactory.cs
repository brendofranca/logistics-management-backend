using Logistics.Management.Application.Commands.Orders;
using Logistics.Management.Application.Requests;

namespace Logistics.Management.Application.Factories
{
    public static class OrderCommandFactory
    {
        public static RequestOrderCommand RequestOrderCommandFromRequest(RequestOrderRequest request) =>
            new(request.Id, request.Description, request.Items.Select(item => (item.ItemId, item.Quantity)).ToList());

        public static CollectOrderCommand CollectOrderCommandFromRequest(CollectOrderRequest request) => new(request.Id, request.AvgId);

        public static SendOrderCommand SendOrderCommandRequest(SendOrderRequest request) => new(request.Id);

        public static ReceiveOrderCommand ReceiveOrderCommandRequest(ReceiveOrderRequest request) => new(request.Id);
    }
}