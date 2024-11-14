namespace SnackHub.Gateway.Models.Order
{
    public class CheckoutOrderRequest
    {
        public required Guid OrderId { get; init; }

        //entender como pode ser feito para passar o parametro PaymentMethod que é esperado no endpoint
    }
}
