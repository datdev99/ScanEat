namespace ScanEat.Application.DTOs.Order
{
    public class OrderItemDto
    {
        public string ProductName { get; set; } = default!;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
