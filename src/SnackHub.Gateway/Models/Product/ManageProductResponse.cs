using Flunt.Notifications;

namespace SnackHub.Gateway.Models.Product
{
    public class ManageProductResponse : Notifiable<Notification>
    {
        public bool IsValid { get; set; }
        public List<string> Notifications { get; set; }
    }
}
