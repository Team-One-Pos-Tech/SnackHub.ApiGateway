using Flunt.Notifications;
using SnackHub.Gateway.Entities;

namespace SnackHub.Gateway.Models.Product
{
    public class ManageProductRequest : Notifiable<Notification>
    {
        public string? Name { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public List<string>? Images { get; set; }
    }
}
