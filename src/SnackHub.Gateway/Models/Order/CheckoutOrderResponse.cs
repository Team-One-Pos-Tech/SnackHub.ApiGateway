using Flunt.Notifications;

namespace SnackHub.Gateway.Models.Order
{
    public class CheckoutOrderResponse : Notifiable<Notification>
    {
        public string? TransactionId { get; set; }
        public string? PaymentStatus { get; set; }
        public DateTime? ProcessedAt { get; set; }
    }
}
