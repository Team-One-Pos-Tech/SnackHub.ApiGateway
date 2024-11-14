using Flunt.Notifications;
using SnackHub.Gateway.ValueObjects;

namespace SnackHub.Gateway.Models.Order
{
    public class CheckPaymentStatusResponse : Notifiable<Notification>
    {
        public OrderStatus? PaymentStatus { get; set; }
    }
}
