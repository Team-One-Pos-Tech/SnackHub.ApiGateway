﻿using Flunt.Notifications;

namespace SnackHub.Gateway.Models.Order
{
    public class OrderResponse : Notifiable<Notification>
    {
        public required Guid Id { get; init; }
        public required IEnumerable<(string ProductName, int Quantity)> Items { get; init; } = [];
        public required string Status { get; init; } = string.Empty;
        public required DateTime CreatedAt { get; init; }
        public required DateTime? UpdatedAt { get; init; }
    }
}
