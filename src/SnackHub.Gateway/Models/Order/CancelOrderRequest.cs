namespace SnackHub.Gateway.Models.Order
{
    public class CancelOrderRequest
    {
        public required Guid OrderId { get; init; }
    }
}
