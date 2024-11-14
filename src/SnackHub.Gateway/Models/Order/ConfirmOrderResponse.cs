﻿using Flunt.Notifications;

namespace SnackHub.Gateway.Models.Order
{
    public class ConfirmOrderResponse : Notifiable<Notification>
    {
        public Guid? OrderId { get; set; }
        public decimal? Total { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
