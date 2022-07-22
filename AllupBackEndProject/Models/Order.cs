﻿using System;

namespace AllupBackEndProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
    }
}
