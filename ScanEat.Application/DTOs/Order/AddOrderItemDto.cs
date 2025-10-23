namespace ScanEat.Application.DTOs.Order
{
    public class AddOrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
