using Flunt.Notifications;

namespace SnackHub.Gateway.Models.Order
{
    public class CancelOrderResponse : Notifiable<Notification>
    {
        public DateTime? CancelledAt { get; set; }
    }
}
