﻿namespace ScanEat.Application.DTOs.Order
{
    public class OrderDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; } = default!;
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }
}
